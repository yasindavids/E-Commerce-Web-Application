using Microsoft.AspNetCore.Mvc;
using ST10269809_POE.Models;

namespace ST10269809_POE.Controllers
{
    public class LoginController : Controller
    {       
        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public ActionResult Login(string email, string name)
        {
            var loginModel = new LoginModel();
            int userId = loginModel.SelectUser(email, name);
            if (userId != -1)
            {
                HttpContext.Session.SetString("UserName", name);
                return RedirectToAction("LoginSuccess", new { name = name });
            }
            else
            {
                // User not found, handle accordingly (e.g., show error message)
                return View("LoginFailed");                    
            }
        }

        [HttpGet]
        public ActionResult Login() {
            var llogin = new LoginModel();
            return View(llogin);
        }

        [HttpGet]
        public ActionResult LoginSuccess(string name)
        {
            // Retrieve additional user data if needed, for now, we pass userId to the view
            ViewBag.name = name;
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Optionally clear authentication cookies
            Response.Cookies.Delete(".AspNetCore.Cookies");

            // Redirect to home page or login page
            return RedirectToAction("Index", "Home");
        }
    }
}
