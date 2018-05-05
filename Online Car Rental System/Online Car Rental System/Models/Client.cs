using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_Car_Rental_System.Models
{
    public class Client
    {
        //basic info
        public int ID { get; set; }

        [Required(ErrorMessage ="You Must Enter Your Name ...")]
        [Display(Name = "Username")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You Must Enter Your password ...")]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "You Must Enter Your SSN ...")]
        public int SSN { get; set; }

        [Required(ErrorMessage = "You Must Enter Your Email ...")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You Must Enter Your Phone ...")]
        public int Phone { get; set; }
        [Required(ErrorMessage ="You Must Enter Your Prefer Type ...")]
        [Display(Name = "Your Prefer Type")]
        public string Type_Pref { get; set; }
    }
}