using System.Collections.Generic;

namespace Users.WebAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public virtual List<Contact> Contacts { get; set; }

        public User()
        {
            Contacts = new List<Contact>();
        }
    }
}