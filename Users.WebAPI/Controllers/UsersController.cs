using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;
using Users.WebAPI.DB;
using Users.WebAPI.Models;

namespace Users.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:61923", "*", "*")]

    public class UsersController : ApiController
    {
        private UserRepository users = new UserRepository(new UsersDbContext());
        [EnableQuery()]
        public IQueryable<User> Get()
        {
            return users.GetUsers().AsQueryable();
        }

        public IEnumerable<User> Get(string search)
        {
            return users.GetUsersWithSearchCriteria(search.ToLower());
        }

        public User GetUser(int id)
        {
            return users.GetUser(id);
        }

        // POST: api/Users
        public User Post([FromBody]User user)
        {
            return users.AddUser(user);
        }

        // PUT: api/Users/5
        public User Put(int id, [FromBody]User user)
        {
            return users.UpdateUser(id, user);
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
