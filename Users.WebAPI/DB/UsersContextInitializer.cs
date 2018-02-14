using System.Collections.Generic;
using System.Data.Entity;
using Users.WebAPI.Models;

namespace Users.WebAPI.DB
{
    public class UsersContextInitializer : DropCreateDatabaseIfModelChanges<UsersDbContext>
    {
        protected override void Seed(UsersDbContext context)
        {
            Contact c1 = new Contact { Value = "Contact1" };
            Contact c2 = new Contact { Value = "Contact2" };
            Contact c3 = new Contact { Value = "Contact3" };
            Contact c4 = new Contact { Value = "Contact4" };
            Contact c5 = new Contact { Value = "Contact5" };
            Contact c6 = new Contact { Value = "Contact6" };

            User u1 = new User { FirstName = "Ivan", LastName = "Ivanov", MiddleName = "Ivanovich", Contacts = new List<Contact>() { c1, c2, c3 } };
            User u2 = new User { FirstName = "Petr", LastName = "Petrov", MiddleName = "Petrovich", Contacts = new List<Contact>() { c4, c5, c6 } };

            context.Users.Add(u1);
            context.Users.Add(u2);
            context.SaveChanges();
        }
    }
}