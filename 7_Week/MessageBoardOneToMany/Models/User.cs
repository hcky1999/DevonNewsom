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
        [Column(TypeName="VARCHAR(45)")]
        public string FirstName {get;set;}
        [Required]
        [Column(TypeName="VARCHAR(45)")]
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
        public string Confirm {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Navigation Properties (NEW!)
        public List<Post> CreatedPosts {get;set;}
    }

    public class LoginUser
    {
        [EmailAddress]
        public string Email {get;set;}
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }
}