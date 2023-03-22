using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Azure.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public void InsertEmployeesToDatabase(Employee employee)
        {
            if (CheckIfUserExists(employee)==true) 
            {
                MessageBox.Show("This user already exists!");
            }
            else
            {
                string sql = "INSERT INTO employee (name, role, username, password) VALUES (@name, @role, @username, @password)";
                using (var command = new NpgsqlCommand(sql, GetPostgreSQLConnection()))
                {
                    command.Parameters.AddWithValue("name", employee.name);
                    command.Parameters.AddWithValue("role", employee.role);
                    command.Parameters.AddWithValue("username", employee.username);
                    command.Parameters.AddWithValue("password", employee.password);

                    try
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }

                }

            }
            

        }
        public bool CheckIfUserExists(Employee employee)
        {
            string sql = "SELECT COUNT(*) FROM Employee WHERE username = @username";
            using (var command = new NpgsqlCommand(sql, GetPostgreSQLConnection()))
            {
                command.Parameters.AddWithValue("username", employee.username);           

                try
                {
                    long count = (long)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    // handle exceptions here, e.g. log error message, show friendly error to user
                    MessageBox.Show(ex.Message);
                }
            }
            return false; // No employee with the given username and password was found

        }
        public void InsertNewAssets(Component comp)
        {
            if (CheckIfComponentExists(comp) == true)
            {
                MessageBox.Show("This asset already exists!");
            }
            else
            {
                string sql = "INSERT INTO component (name, quantity, maxQuantity, price) VALUES (@name, 0, @maxQuantity, @price)";
                using (var command = new NpgsqlCommand(sql, GetPostgreSQLConnection()))
                {
                    command.Parameters.AddWithValue("name", comp.name);
                    command.Parameters.AddWithValue("maxQuantity", comp.maxQuantity);
                    command.Parameters.AddWithValue("price", comp.price);

                    try
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    MessageBox.Show("Asset inserted!");

                }

            }

        }
        public bool CheckIfComponentExists(Component comp)
        {
            string sql = "SELECT COUNT(*) FROM component WHERE name = @name";
            using (var command = new NpgsqlCommand(sql, GetPostgreSQLConnection()))
            {
                command.Parameters.AddWithValue("name", comp.name);

                try
                {
                    long count = (long)command.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    // handle exceptions here, e.g. log error message, show friendly error to user
                    MessageBox.Show(ex.Message);
                }
            }
            return false; // No employee with the given username and password was found
        }



        public List<Component> LoadComponents()
        {
            try
            {
                // Create a connection to the PostgreSQL database
            
                    // Create a command to select the data from the table
                    using (NpgsqlCommand command = new NpgsqlCommand($"SELECT componentID, name, quantity, maxQuantity, price FROM component", GetPostgreSQLConnection()))
                    {
                        // Execute the command and read the results
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            // Create a list to hold the Component objects
                            List<Component> components = new List<Component>();

                            // Loop through the results and add them to the ComboBox and the list
                            while (reader.Read())
                            {
                                Component component = new Component
                                {
                                    componentID = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    quantity = reader.GetInt32(2),
                                    maxQuantity = reader.GetInt32(3),
                                    price = reader.GetInt32(4)
                                };
                                components.Add(component);
                            }

                        // Store the list of components in the ComboBox's Tag property
                        return components;
                        }
                    }              
            }
            catch (Exception ex)
            {
                // Handle any errors that occur
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void UpdatePriceOfComponent(string component,int price)
        {
            string id = component.Split(' ')[0];
            string sql = "UPDATE component set price = @price WHERE componentid = @id";
            using (var command = new NpgsqlCommand(sql, GetPostgreSQLConnection()))
            {
                command.Parameters.AddWithValue("id", int.Parse(id));
                command.Parameters.AddWithValue("price", price);

                try
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                MessageBox.Show("The product's price has benn updated.");
            }
        }
    }



}

