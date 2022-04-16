using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using DemoApp.BusinessLogic;

namespace DemoApp.DataLogic
{
    public class SQLRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SQLRepository> _logger;

        // Constructors
        public SQLRepository(string connectionString, ILogger<SQLRepository> logger)
        {
            this._connectionString = connectionString;
            this._logger = logger;
        }

        // Methods

        // Customer methods
        public async Task<List<Customer>> GetAllCustomers()
        {
            List<Customer> result = new List<Customer>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM Customer";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string? order_content = null;
                int Id = reader.GetInt32(0);
                string first_name = reader.GetString(1);
                string last_name = reader.GetString(2);
                int? session_total = reader.GetInt32(3);
                if (reader.IsDBNull(4))
                    {
                    order_content = "No orders found";
                    }
                else
                    {
                    order_content = reader.GetString(4);
                    }
                DateTime created_at = reader.GetDateTime(5);
                DateTime updated_at = reader.GetDateTime(6);
                int location_id = reader.GetInt32(7);
                result.Add(new Customer(Id, first_name, last_name, session_total, order_content, created_at, updated_at, location_id));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllCustomers");

            return result;
        }
        public async Task<List<Customer>> GetCustomer(string input)
        {
            List<Customer> result = new List<Customer>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                $"SELECT * FROM Customer WHERE (first_name = '{input}') OR (last_name = '{input}')";


            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string? order_content = null;
                int Id = reader.GetInt32(0);
                string first_name = reader.GetString(1);
                string last_name = reader.GetString(2);
                int? session_total = reader.GetInt32(3);
                if (reader.IsDBNull(4))
                {
                    order_content = "No orders found";
                }
                else
                {
                    order_content = reader.GetString(4);
                };
                DateTime created_at = reader.GetDateTime(5);
                DateTime updated_at = reader.GetDateTime(6);
                int location_id = reader.GetInt32(7);
                result.Add(new Customer(Id, first_name, last_name, session_total, order_content, created_at, updated_at, location_id));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetCustomer");

            return result;
        }

        // Location methods
        public async Task<List<Location>> GetAllLocations()
        {
            List<Location> result = new List<Location>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM Location";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                DateTime created_at = reader.GetDateTime(2);
                DateTime updated_at = reader.GetDateTime(3);
                result.Add(new Location(id, name, created_at, updated_at));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllLocations");

            return result;
        }
        public async Task<Location> GetLocation(int input)
        {
            Location result = new(0, "", DateTime.UtcNow, DateTime.UtcNow);
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = $"SELECT * FROM Location WHERE id = {input}";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result.id = reader.GetInt32(0);
                result.name = reader.GetString(1);
                result.CreatedAt = reader.GetDateTime(2);
                result.UpdatedAt = reader.GetDateTime(3);
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetLocation");

            return result;
        }

        // Employee Methods 
        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM Employee";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string username = reader.GetString(1);
                string password = reader.GetString(2);
                DateTime created_at = reader.GetDateTime(3);
                DateTime updated_at = reader.GetDateTime(4);
                int location_id = reader.GetInt32(5);
                result.Add(new Employee(id, username, password, location_id, created_at, updated_at));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllEmployees");

            return result;
        }
        public async Task<List<Employee>> GetEmployee(string input)
        {
            List<Employee> result = new List<Employee>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = $"SELECT * FROM Employee WHERE username = '{input}'";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string username = reader.GetString(1);
                string password = reader.GetString(2);
                DateTime created_at = reader.GetDateTime(3);
                DateTime updated_at = reader.GetDateTime(4);
                int location_id = reader.GetInt32(5);
                result.Add(new Employee(id, username, password, location_id, created_at, updated_at));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetEmployee");

            return result;
        }

        // Product Methods 
        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> result = new List<Product>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString = "SELECT * FROM Product";

            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int amount = reader.GetInt32(2);
                decimal price = reader.GetDecimal(3);
                string description = reader.GetString(4);
                DateTime created_at = reader.GetDateTime(5);
                DateTime updated_at = reader.GetDateTime(6);
                int location_id = reader.GetInt32(7);
                result.Add(new Product(id, name, amount, price, description, created_at, updated_at, location_id));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetAllProducts");

            return result;
        }
        public async Task<List<Product>> GetProduct(string input)
        {
            List<Product> result = new List<Product>();

            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            string cmdString =
                $"SELECT * FROM Product WHERE (name = '{input}') OR (location_id = {Int32.Parse(input)})";


            using SqlCommand cmd = new(cmdString, connection);

            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int amount = reader.GetInt32(2);
                decimal price = reader.GetDecimal(3);
                string description = reader.GetString(4);
                DateTime created_at = reader.GetDateTime(5);
                DateTime updated_at = reader.GetDateTime(6);
                int location_id = reader.GetInt32(7);
                result.Add(new Product(id, name, amount, price, description, created_at, updated_at, location_id));
            }
            await connection.CloseAsync();

            _logger.LogInformation("Executed: GetProduct");

            return result;
        }

    }
}
