using Microsoft.AspNetCore.Mvc;

using ST10269809_POE.Data;
using ST10269809_POE.Models;


namespace ST10269809_POE.Controllers
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int ProductPrice { get; set; }
    }
    public class OrderController : Controller
    {
        private readonly DataAccess data;
        private readonly LoginModel l;
        public OrderDatabase db;

        public OrderController()
        {
            data = new DataAccess();
            db = new OrderDatabase();

        }


        public ActionResult AddToOrder(string productName)
        {
            string userName = HttpContext.Session.GetString("UserName");
            if (string.IsNullOrEmpty(userName))
            {
                
                return RedirectToAction("Login", "Login");
            }
            var data = new DataAccess();
            
            int productPrice = data.GetproductPrice(productName);

            ViewBag.ProductName = productName;
            ViewBag.ProductPrice = productPrice;
            ViewBag.UserName = userName;

            return View();
        }

        public ActionResult PlaceOrder(string productName) {

            var data = new DataAccess();
            int productId = data.GetproductID(productName);
            int productPrice = data.GetproductPrice(productName);
            string userName = HttpContext.Session.GetString("UserName");

            int userID = db.SelectID(userName);
           

            var result = db.InsertRow(productId, userID, productPrice);
            return RedirectToAction("OrderSuccess", "Home");
        }
    }
}
