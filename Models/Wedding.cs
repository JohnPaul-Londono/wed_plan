using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace wed_plan.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }
        [Required]
        public string person1 { get; set; }
        [Required]
        public string person2 { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime dateofWedding { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<RSVP> guestlist { get; set; }

        public int UserId { get; set; }
        public User planner { get; set; }
        






    }
}