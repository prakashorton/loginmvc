using LoginMVC.Manager;
using LoginMVC.Models;
using System.Web.Mvc;

namespace LoginMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public bool CheckLogin(Register register)
        {
            LoginManager login = new LoginManager();
            return login.CheckLogin(register);
        }

        [HttpPost]
        public Register RegisterUser(Register register)
        {
            LoginManager login = new LoginManager();
            return login.RegisterUser(register);
        }
    }
}
