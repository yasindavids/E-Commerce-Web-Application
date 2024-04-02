using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10269809_POE.Models
{
    public class userTable : Controller
    {

        public static string con_string = "Server=tcp:cldv-poe-server.database.windows.net,1433;Initial Catalog=CloudDev-POE-DB;Persist Security Info=False;User ID=yasin;Password={Eukanuba101};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

        public IActionResult Index()
        {
            return View();
        }
    }
}
