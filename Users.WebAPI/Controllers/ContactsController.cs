using System.Web.Http;
using Users.WebAPI.DB;

namespace Users.WebAPI.Controllers
{
    public class ContactsController : ApiController
    {
        private ContactRepository repo = new ContactRepository(new UsersDbContext());

        // POST: api/Contacts
        public void Post([FromBody]int id)
        {
            repo.DeleteContact(id);
        }
    }
}
