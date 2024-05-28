using Microsoft.AspNetCore.Mvc;
using ST10269809_POE.Data;
using ST10269809_POE.Models;
using System.Diagnostics;

namespace ST10269809_POE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataAccess db;
        private readonly OrderDatabase data;


        public HomeController(ILogger<HomeController> logger)
        {
            data = new OrderDatabase();
            db = new DataAccess();
            _logger = logger;
        }
        public IActionResult Orders()
        {
            string userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {

                return RedirectToAction("Login", "Login");
            }
            int userID = data.SelectID(userName);
            
            var orders = db.GetOrdersByUserID(userID);
            return View(orders);
        }
        public IActionResult MyWork()
        {

            return View();
        }
        public IActionResult Index()
        {       
            return View();  
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
