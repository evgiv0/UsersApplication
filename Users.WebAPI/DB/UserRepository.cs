using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Users.WebAPI.Models;

namespace Users.WebAPI.DB
{
    public class UserRepository
    {
        private readonly UsersDbContext _context;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Include(u => u.Contacts).ToList();
        }

        public void AddUser(User newUser)
        {
            _context.Users.Add(newUser);
        }
    }
}