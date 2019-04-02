using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ModelValidations.Models.Validations;

namespace ModelValidations.Models
{
    public class Person
    {
        // Ed, Al, Ng, A, X
        [MinLength(2)]
        [Required]
        [Display(Name="First Name")]
        public string FirstName {get;set;}
        [Required(ErrorMessage="Last Name is required!!!")]
        [MaxLength(25, ErrorMessage="Last Name must be 25 characters or less")]
        public string LastName {get;set;}
        [Required]
        public string Location {get;set;}
        [EmailAddress]
        [Required]
        public string Email {get;set;}
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password {get;set;}
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirm {get;set;}
        // Level 1: no future dates
        // Level 2: check for at least some age (13)
        [OldEnough]
        public DateTime DOB {get;set;}

        public int Age 
        {
            get { return (DateTime.Now - DOB).Days / 365; }
        }
    }
    public class ComplexViewModel
    {
        public List<Person> People {get;set;}
        public Person OnePerson {get;set;}
        public Dog OneDog {get;set;}
        public int[] Numbers {get;set;}
    }

    public class Dog
    {

    }
}