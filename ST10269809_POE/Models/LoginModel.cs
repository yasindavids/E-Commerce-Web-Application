using System.Data.SqlClient;

namespace ST10269809_POE.Models
{
    public class LoginModel
    {

        public static string con_string = "Server=tcp:cldv-poe-server.database.windows.net,1433;Initial Catalog=CloudDev-POE-DB;Persist Security Info=False;User ID=yasin;Password=Eukanuba101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        


        public int SelectUser(string email, string name)
        {
            int userId = -1; 
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
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
            }
            return userId;
        }
    }
}
