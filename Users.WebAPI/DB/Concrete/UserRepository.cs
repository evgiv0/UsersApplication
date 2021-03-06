﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Users.WebAPI.Models;

namespace Users.WebAPI.DB.Concrete
{
    public class UserRepository : IUserRepository
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

        public UsersViewModel GetUsers()
        {
            var users = _context.Users.Include(u => u.Contacts).ToList();
            var count = users.Count;

            return new UsersViewModel { Users = users, CountUser = count };
        }

        public IEnumerable<User> GetUsersWithSearchCriteria(string search)
        {
            return _context.Users.Where(u => u.FirstName.ToLower().Contains(search)
                                        || u.LastName.ToLower().Contains(search)
                                        || u.MiddleName.ToLower().Contains(search))
                                        .ToList();
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User IsUserForUpdateExists(int id)
        {
            return _context.Users.Where(u => u.UserId == id).Include(u => u.Contacts).SingleOrDefault();

        }

        public User UpdateUser(User existingUser, User newUser)
        {
            var userForSave = _context.Entry(existingUser);
            userForSave.CurrentValues.SetValues(newUser);

            foreach (var contact in newUser.Contacts)
            {
                var originalContact = existingUser.Contacts
                    .Where(c => c.ContactId == contact.ContactId && c.ContactId != 0)
                    .SingleOrDefault();

                if (originalContact != null)
                {
                    var contactEntry = _context.Entry(originalContact);
                    contactEntry.CurrentValues.SetValues(contact);
                }
                else
                {
                    contact.ContactId = 0;
                    existingUser.Contacts.Add(contact);
                }
            }
            foreach (var originalContact in
                         existingUser.Contacts.Where(c => c.ContactId != 0).ToList())
            {

                if (!newUser.Contacts.Any(c => c.ContactId == originalContact.ContactId))
                    _context.Contacts.Remove(originalContact);
            }

            _context.SaveChanges();

            return existingUser;
        }
    }
}