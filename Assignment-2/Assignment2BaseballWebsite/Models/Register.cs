using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2BaseballWebsite.Models
{
    public class Register
    {
        [Key]
        public virtual int RegisterId { get; set; }

        [Required]
        [Display(Name = "Players First Name")]
        public virtual String FirstName { get; set; }

        [Required]
        [Display(Name = "Players Last Name")]
        public virtual String LastName { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public virtual Char Gender { get; set; }

        [Required]
        [Display(Name = "Birth Month")]
        public virtual Byte BirthMonth { get; set; }

        [Required]
        [Display(Name = "Birth Day")]
        public virtual Byte BirthDay { get; set; }

        [Required]
        [Display(Name = "Birth Year")]
        public virtual int BirthYear { get; set; }



        [Required]
        [Display(Name = "Street Number")]
        public virtual int StreetNumber { get; set; }

        [Required]
        [Display(Name = "Street Name")]
        public virtual String StreetName { get; set; }

        [Required]
        [Display(Name = "City")]
        public virtual String City { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public virtual String PostalCode { get; set; }



        [Required]
        [Display(Name = "Phone Number")]
        public virtual int PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        public virtual String EmailAddress { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public virtual String EmergencyFirstName { get; set; }



        [Required]
        [Display(Name = "Last Name")]
        public virtual String EmergencyLastName { get; set; }

        [Required]
        [Display(Name = "Relationship")]
        public virtual String EmergencyRelationship { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public virtual int EmergencyPhoneNumber { get; set; }


    }
}


    
