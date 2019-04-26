using Microsoft.EntityFrameworkCore;

namespace MessageBoard.Models
{
    public class MessageBoardContext : DbContext
    {
        public MessageBoardContext(DbContextOptions options) : base(options) {}
        public DbSet<Post> Posts {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<Vote> Votes {get;set;}
    }
}