using System.Collections.Generic;
using System.Web.Http;
using Users.WebAPI.DB;
using Users.WebAPI.Models;

namespace Users.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private UserRepository users = new UserRepository(new UsersDbContext());
        public IEnumerable<User> Get()
        {
            return users.GetUsers();
        }

        // GET: api/Users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
