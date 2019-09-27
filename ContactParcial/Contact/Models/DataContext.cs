using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Contact.Models
{
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Contact.Models.FriendContact> FriendContacts { get; set; }
    }
}