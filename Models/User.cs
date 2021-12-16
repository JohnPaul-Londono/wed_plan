using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wed_plan.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string eMail { get; set; }
        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        public List<RSVP> Attending { get; set; }
        public List<Wedding> myWeddings { get; set; }
        [NotMapped]
        [Compare("password")]
        [DataType(DataType.Password)]
        public string confirm { get; set; }
    }
}