using System;
using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
    public class Post
    {
        public int PostId {get;set;}
        [Required]
        public string Username {get;set;}
        [Required]
        public string Topic {get;set;}
        [Required]
        [MinLength(10, ErrorMessage="Post must be 10 characters or longer!")]
        public string Content {get;set;}
    }
}