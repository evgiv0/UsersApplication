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

        public User GetUser(int id)
        {
            User user;
            if (id > 0)
                user = _context.Users.FirstOrDefault(u => u.UserId == id);
            else
                user = new User();
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.Include(u => u.Contacts).ToList();
        }

        public IEnumerable<User> GetUsersWithSearchCriteria(string search)
        {
            return _context.Users.Where(u => u.FirstName.ToLower().Contains(search)
                                        || u.LastName.ToLower().Contains(search)
                                        || u.MiddleName.ToLower().Contains(search))
                                        .ToList();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(int id, User newUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);

            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.MiddleName = newUser.MiddleName;
            user.Contacts = newUser.Contacts;
            _context.SaveChanges();
        }
    }
}