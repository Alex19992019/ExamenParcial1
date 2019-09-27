using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Contact.Models;

namespace Contact.Controllers
{
    public class FriendContactsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/FriendContacts
        public IQueryable<FriendContact> GetFriendContacts()
        {
            return db.FriendContacts;
        }

        // GET: api/FriendContacts/5
        [ResponseType(typeof(FriendContact))]
        public IHttpActionResult GetFriendContact(int id)
        {
            FriendContact friendContact = db.FriendContacts.Find(id);
            if (friendContact == null)
            {
                return NotFound();
            }

            return Ok(friendContact);
        }

        // PUT: api/FriendContacts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFriendContact(int id, FriendContact friendContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != friendContact.FriendId)
            {
                return BadRequest();
            }

            db.Entry(friendContact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FriendContacts
        [ResponseType(typeof(FriendContact))]
        public IHttpActionResult PostFriendContact(FriendContact friendContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FriendContacts.Add(friendContact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = friendContact.FriendId }, friendContact);
        }

        // DELETE: api/FriendContacts/5
        [ResponseType(typeof(FriendContact))]
        public IHttpActionResult DeleteFriendContact(int id)
        {
            FriendContact friendContact = db.FriendContacts.Find(id);
            if (friendContact == null)
            {
                return NotFound();
            }

            db.FriendContacts.Remove(friendContact);
            db.SaveChanges();

            return Ok(friendContact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FriendContactExists(int id)
        {
            return db.FriendContacts.Count(e => e.FriendId == id) > 0;
        }
    }
}