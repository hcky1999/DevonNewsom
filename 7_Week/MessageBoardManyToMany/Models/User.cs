using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageBoard.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        [Display(Name="First Name")]
        [Column(TypeName="VARCHAR(45)")]
        public string FirstName {get;set;}
        [Required]
        [Column(TypeName="VARCHAR(45)")]
        [Display(Name="Last Name")]
        public string LastName {get;set;}
        [Column(TypeName="VARCHAR(45)")]
        [EmailAddress]
        [Required]
        public string Email {get;set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password")]
        [Display(Name="Confirm Password")]
        public string Confirm {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Navigation Properties (NEW!)
        public List<Post> CreatedPosts {get;set;}
        public List<Vote> Votes {get;set;}
    }

    public class LoginUser
    {
        [EmailAddress]
        [Display(Name="Email")]
        public string LogEmail {get;set;}
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string LogPassword {get;set;}
    }
}