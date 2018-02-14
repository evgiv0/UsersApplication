using System.Linq;
using System.Web.Mvc;
using Users.WebAPI.DB;

namespace Users.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public UsersDbContext db = new UsersDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Test()
        {
            var result = db.Users.FirstOrDefault();

            return View(result);
        }
    }
}
