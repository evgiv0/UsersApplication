using System.Collections.Generic;
using Users.WebAPI.Models;

namespace Users.WebAPI.DB
{
    public interface IUserRepository
    {
        User GetUser(int id);
        UsersViewModel GetUsers();
        IEnumerable<User> GetUsersWithSearchCriteria(string search);
        User AddUser(User user);
        User UpdateUser(User existingUser, User newUser);
        User IsUserForUpdateExists(int id);
    }
}