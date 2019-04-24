using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageBoard.Models
{
    [Table("posts")]
    public class Post
    {
        [Key]
        public int PostId {get;set;}
        [Required]
        public string Username {get;set;}
        [Required]
        public string Topic {get;set;}
        [Required]
        [MinLength(10, ErrorMessage="Post must be 10 characters or longer!")]
        public string Content {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public Post()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}