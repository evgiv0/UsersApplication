using System.Web.Http;
using System.Web.Http.Cors;
using Users.WebAPI.DB;
using Users.WebAPI.Models;

namespace Users.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:61923", "*", "*")]

    public class UsersController : ApiController
    {
        private UserRepository repo = new UserRepository(new UsersDbContext());

        public UserViewModel Get()
        {
            return repo.GetUsers();
        }

        public User GetUser(int id)
        {
            return repo.GetUser(id);
        }

        // POST: api/Users
        public User Post([FromBody]User user)
        {
            return repo.AddUser(user);
        }

        // PUT: api/Users/5
        public User Put(int id, [FromBody]User user)
        {
            return repo.UpdateUser(id, user);
        }
    }
}
