using Microsoft.EntityFrameworkCore;

namespace DojoSecrets.Models
{
    public class DojoSecretsContext : DbContext
    {
        public DojoSecretsContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users {get;set;}
        public DbSet<Secret> Secrets {get;set;}
        public DbSet<Like> Likes {get;set;}
    }
}