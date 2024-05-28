namespace ST10269809_POE.Models
{
    
    using System.Data.SqlClient;
           
    public class UserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }

    public class Database
    {
        private static string con_string = "Server=tcp:cldv-poe-server.database.windows.net,1433;Initial Catalog=CloudDev-POE-DB;Persist Security Info=False;User ID=yasin;Password=Eukanuba101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public int InsertUser(UserModel m)
        {
            string sql = "INSERT INTO userTable (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email)";

            try
            {
                using (SqlConnection con = new SqlConnection(con_string))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", m.Name);
                        cmd.Parameters.AddWithValue("@Surname", m.Surname);
                        cmd.Parameters.AddWithValue("@Email", m.Email);

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
