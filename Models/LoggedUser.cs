using System;
using System.ComponentModel.DataAnnotations;



namespace wed_plan.Models
{
    public class LoggedUser
    {

        [Required]
        [EmailAddress]
        public string leMail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string lpassword { get; set; }
    }
}