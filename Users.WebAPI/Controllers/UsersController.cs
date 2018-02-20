using System.Web.Http;
using System.Web.Http.Cors;
using Users.WebAPI.DB.Abstract;
using Users.WebAPI.Models;

namespace Users.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:61923", "*", "*")]

    public class UsersController : ApiController
    {
        private IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UsersViewModel Get()
        {
            return _unitOfWork.Users.GetUsers();
        }

        public User GetUser(int id)
        {
            return _unitOfWork.Users.GetUser(id);
        }

        // POST: api/Users
        public User Post([FromBody]User user)
        {
            return _unitOfWork.Users.AddUser(user);
        }

        // PUT: api/Users/5
        public User Put(int id, [FromBody]User user)
        {
            return _unitOfWork.Users.UpdateUser(id, user);
        }
    }
}
