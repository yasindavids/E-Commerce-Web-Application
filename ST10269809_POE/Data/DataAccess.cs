using System.Data.SqlClient;
namespace ST10269809_POE.Data


{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        
    }
    public class DataAccess
    {
        public static string _connectionString = "Server=tcp:cldv-poe-server.database.windows.net,1433;Initial Catalog=CloudDev-POE-DB;Persist Security Info=False;User ID=yasin;Password=Eukanuba101;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public List<Order> GetOrdersByUserID(int userID)
        {
            List<Order> orders = new List<Order>();

            string query = "SELECT * FROM orderTable WHERE userID = @UserID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = new Order
                            {
                                OrderID = Convert.ToInt32(reader["orderID"]),
                                ProductID = Convert.ToInt32(reader["productIDs"]),
                                UserID = Convert.ToInt32(reader["userID"]),
                                
                            };
                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }

        public int GetproductID(string name)
        {
            int result = 0;
            string query = "SELECT productID FROM productTable WHERE productName = @Name";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    try
                    {
                        connection.Open();
                        object queryResult = command.ExecuteScalar();
                        if (queryResult != null && queryResult != DBNull.Value)
                        {
                            result = Convert.ToInt32(queryResult);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                        // Handle the exception appropriately
                    }
                }
            }
            return result;
        }

        public int GetproductPrice(string name)
        {
            int result = 0;
            string query = "SELECT productPrice FROM productTable WHERE productName = @Name";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    try
                    {
                        connection.Open();
                        object queryResult = command.ExecuteScalar();
                        if (queryResult != null && queryResult != DBNull.Value)
                        {
                            result = Convert.ToInt32(queryResult);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                        // Handle the exception appropriately
                    }
                }
            }
            return result;
        }



    }
}