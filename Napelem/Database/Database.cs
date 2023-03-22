using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Azure.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;

namespace Napelem.Database
{
    public class Database
    {

        public NpgsqlConnection GetPostgreSQLConnection()
        {
            string connectionString = "Server=localhost;Port=5432;Database=mydatabase;User Id=postgres;Password=password;";
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }
            return connection;
        }

        public void CreateTables(NpgsqlConnection connection)
        {
            var createEmployeeTable = @"
        CREATE TABLE Employee (
            employeeID SERIAL PRIMARY KEY,
            name VARCHAR(255) NOT NULL,
            role VARCHAR(255) NOT NULL,
            username VARCHAR(255) NOT NULL,
            password VARCHAR(255) NOT NULL
        );";

            var createProjectTable = @"
        CREATE TABLE Project (
            projectID SERIAL PRIMARY KEY,
            employeeID INTEGER NOT NULL,
            name VARCHAR(255) NOT NULL,
            status VARCHAR(255) NOT NULL,
            projectPrice INTEGER NOT NULL,
            FOREIGN KEY (employeeID) REFERENCES Employee (employeeID)
        );";

            var createLogTable = @"
        CREATE TABLE Log (
            logID SERIAL PRIMARY KEY,
            projectID INTEGER NOT NULL,
            status VARCHAR(255) NOT NULL,
            timestamp timestamp NOT NULL,
            FOREIGN KEY (projectID) REFERENCES Project (projectID)
        );";

            var createReservationTable = @"
        CREATE TABLE Reservation (
            reservationID SERIAL PRIMARY KEY,
            projectID INTEGER NOT NULL,
            componentID INTEGER NOT NULL,
            FOREIGN KEY (projectID) REFERENCES Project (projectID),
            FOREIGN KEY (componentID) REFERENCES Component (componentID)
        );";

            var createComponentTable = @"
        CREATE TABLE Component (
            componentID SERIAL PRIMARY KEY,
            name VARCHAR(255) NOT NULL,
            quantity INTEGER NOT NULL,
            maxQuantity INTEGER NOT NULL,
            price INTEGER NOT NULL
        );";

            var createStorageTable = @"
        CREATE TABLE Storage (
            storageID SERIAL PRIMARY KEY,
            componentID INTEGER NOT NULL,
            rows INTEGER NOT NULL,
            columns INTEGER NOT NULL,
            level INTEGER NOT NULL,
            FOREIGN KEY (componentID) REFERENCES Component (componentID)
        );";

            using (var command = new NpgsqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = createEmployeeTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createProjectTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createLogTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createComponentTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createReservationTable;
                    command.ExecuteNonQuery();

                    command.CommandText = createStorageTable;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
        public Employee GetEmployeeByUsernameAndPassword(string username, string password)
        {
          
            string sql = "SELECT * FROM Employee WHERE username = @username AND password= @password";
            using (var command = new NpgsqlCommand(sql, GetPostgreSQLConnection()))
            {
                command.Parameters.AddWithValue("username", username);
                command.Parameters.AddWithValue("password", password);

                try
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var employee = new Employee
                            {
                                employeeID = reader.GetInt32(reader.GetOrdinal("employeeID")),
                                name = reader.GetString(reader.GetOrdinal("name")),
                                role = reader.GetString(reader.GetOrdinal("role")),
                                username = reader.GetString(reader.GetOrdinal("username")),
                                password = reader.GetString(reader.GetOrdinal("password")),
                            };
                            return employee;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // handle exceptions here, e.g. log error message, show friendly error to user
                    Console.WriteLine(ex.Message);
                }
            }
            return null; // No employee with the given username and password was found
        }

    } 



}

/*
using (NpgsqlConnection connection = GetPostgreSQLConnection())
{
    using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM my_table", connection))
    {
        using (NpgsqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                // process results
            }
        }
    }
}*/
