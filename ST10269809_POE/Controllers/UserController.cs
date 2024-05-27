using Microsoft.AspNetCore.Mvc;
using ST10269809_POE.Models;


namespace ST10269809_POE.Controllers
{
    public class UserController : Controller
    {
        public Database db = new Database();

        [HttpPost]
        public ActionResult SignUp(UserModel Users)
        {
            if (ModelState.IsValid)
            {
                var result = db.InsertUser(Users);
                return RedirectToAction("Privacy", "Home");
            }
            return View(Users); // If the model is not valid, return the view with the current model
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            var user = new UserModel(); // Create a new instance of userTable
            return View(user); // Pass the new userTable instance to the view
        }
    }
}




