using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HW5_MajorMinorForm.Models
{
    public class User
    {

        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Catalog Year")]
        public int CatalogYear { get; set; }

        [Required]
        [Display(Name = "V Number")]
        public int VNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string EMail { get; set; }

        [Required]
        [Display(Name = "Major")]
        public string Major { get; set; }

        [Required]
        [Display(Name = "Minor")]
        public string Minor { get; set; }

        [Required]
        [Display(Name = "Advisor")]
        public string Advisor { get; set; }

    }
}