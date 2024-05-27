using System.Data.SqlClient;

namespace ST10269809_POE.Models
{
    public class productTable
    {
        public static string con_string = "Server=tcp:cldv-poe-server.database.windows.net,1433;Initial Catalog=CloudDev-POE-DB;Persist Security Info=False;User ID=yasin;Password={Eukanuba101};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public static SqlConnection con = new SqlConnection(con_string);

        public string Name { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public string Availability { get; set; }



        public int insert_product(productTable p)
        {
            try
            {
                string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw ex;
            }
        }
    }
}
