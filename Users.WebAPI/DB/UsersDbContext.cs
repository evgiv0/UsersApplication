using System.Data.Entity;
using Users.WebAPI.Models;

namespace Users.WebAPI.DB
{
    public class UsersDbContext : DbContext
    {
        static UsersDbContext()
        {
            Database.SetInitializer<UsersDbContext>(new UsersContextInitializer());
        }
        public UsersDbContext()
            : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}