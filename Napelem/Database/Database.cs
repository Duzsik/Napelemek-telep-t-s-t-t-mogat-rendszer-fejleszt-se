using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Napelem.Database
{
    public class Database
    {
        public void CreateDatabaseConnection()
        {
            // Connection string parameters
            string host = "localhost";
            string database = "mydatabase";
            string username = "myusername";
            string password = "mypassword";

            // Build connection string
            string connString = $"Host={host};Database={database};Username={username};Password={password}";

            // Create connection object
            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    // Open connection
                    conn.Open();

                    // Do something with the connection
                    Console.WriteLine("Connection opened successfully.");

                    // Close connection
                    conn.Close();
                    Console.WriteLine("Connection closed successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

    }
    



}
