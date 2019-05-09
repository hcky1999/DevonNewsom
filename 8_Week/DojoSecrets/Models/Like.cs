using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoSecrets.Models
{
    [Table("likes")]
    public class Like
    {
        [Key]
        public int LikeId {get;set;}
        public int UserId {get;set;}
        public int SecretId {get;set;}
        // NAVIGATION PROPERTIES
        public User Liker {get;set;}
        public Secret LikedSecret {get;set;}
    }
}