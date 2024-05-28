namespace ST10269809_POE.Models
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Identity.Client;
    using System.Data.SqlClient;

   

    public class OrderDatabase() {
        private readonly string con_string = "Server=tcp:cldv-poe-server.database.windows.net,1433;Initial Catalog=CloudDev-POE-DB;Persist Security Info=False;User ID=yasin;Password=Eukanuba101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int SelectID(string name)
        {
            using (SqlConnection con = new SqlConnection(con_string))
            {
                int userId = -1;
                string sql = "SELECT userID FROM userTable WHERE userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@Name", name);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while inserting the user", ex);

                }
                return userId;
            }
        }

        public int InsertRow(int productID, int userID, int price)
        {
            string sql = "INSERT INTO orderTable (userID, totalPrice, productIDs) VALUES (@userID, @Price, @productID)";
            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@userID", userID);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@productID", productID);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                // For now, rethrow the exception
                throw new Exception("An error occurred while inserting the user", ex);
            }
        }

    }

}
 
