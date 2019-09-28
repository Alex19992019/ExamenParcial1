using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contact.Models
{
    public class FriendContact
    {
        public enum TypeList
        {
            Sally,
            Sonia,
            Sarah,
            Sam,
            Summer

        }

        [Key]
        public int FriendId { get; set; }
        [Required]
        [Range(5,50)]
        [Display(Description = "Complete Name")]
        public string name { get; set; }

        public TypeList List { get; set; }

        [Required]
        [EmailAddress]

        public string email { get; set; }

        [DataType(DataType.Date)]
        [Display(Description = "Birthday")]
        public DateTime BirthDate { get; set; }
    }
}