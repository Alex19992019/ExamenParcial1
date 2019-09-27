using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contact.Models
{
    public class FriendContact
    {
        public enum ListType
        {
            Alejandra,
            Rodrigo,
            Rossy,
            Carmelo,
            Bernarda
        }
        [Key]
        public int FriendId { get; set; }
        [Required]
        [Range(5,50)]
        public string name { get; set; }

        public ListType LastName { get; set; }

        [Required]
        [EmailAddress]

        public string email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
    }
}