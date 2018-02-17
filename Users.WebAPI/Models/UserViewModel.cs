using System.Collections.Generic;

namespace Users.WebAPI.Models
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public int CountUser { get; set; }
    }
}