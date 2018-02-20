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

        public IHttpActionResult Get()
        {
            return Ok(_unitOfWork.Users.GetUsers());
        }

        public IHttpActionResult GetUser(int id)
        {
            return Ok(_unitOfWork.Users.GetUser(id));
        }

        // POST: api/Users
        public IHttpActionResult Post([FromBody]User user)
        {
            if (user == null)
                return BadRequest();

            var newUser = _unitOfWork.Users.AddUser(user);

            return Created<User>(Request.RequestUri + newUser.UserId.ToString(), newUser);
        }

        // PUT: api/Users/5
        public IHttpActionResult Put(int id, [FromBody]User user)
        {
            if (user == null)
                return BadRequest();
            var existingUser = _unitOfWork.Users.IsUserForUpdateExists(id);
            if (existingUser == null)
                return NotFound();
            return Ok(_unitOfWork.Users.UpdateUser(existingUser, user));
        }
    }
}
