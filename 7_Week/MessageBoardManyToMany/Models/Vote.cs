using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageBoard.Models
{
    [Table("votes")]
    public class Vote
    {
        [Key]
        public int VoteId {get;set;}
        public bool IsUpvote {get;set;}
        public int PostId {get;set;}
        public int UserId {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public User Voter {get;set;}
        public Post VotedPost {get;set;}
    }
}