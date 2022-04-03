using System;
using System.Collections.Generic;
using Proj_0.Models;
using System.Data.SqlClient;

namespace Proj_0.Data
{
    public class SqlRepository : IRepository
    {
        private readonly string _connectionString;

        public SqlRepository(string connectionString)
        {
            this._connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> result = new List<Employee>();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new("SELECT * FROM Employee", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string username = reader.GetString(1);
                string password = reader.GetString(2);
                byte admin = reader.GetByte(3);
                int location_id = reader.GetInt32(6);
                DateTime CreatedAt = reader.GetDateTime(4);
                DateTime UpdatedAt = reader.GetDateTime(5);

                result.Add(new(id, username, password, admin, location_id, CreatedAt, UpdatedAt));
            }

            connection.Close();
            return result;
        }
        public List<Location> GetAllLocations()
        {
            List<Location> result = new List<Location>();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new("SELECT * FROM Location", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                DateTime CreatedAt = reader.GetDateTime(2);
                DateTime UpdatedAt = reader.GetDateTime(3);
                result.Add(new Location (id, name, CreatedAt, UpdatedAt));
            }

            connection.Close();
            return result;
        }

        public string FindUsername(string username, int location_id)
        {
            string result = "";
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new($"SELECT username, location_id FROM Employee WHERE username = '{username}' AND location_id = {location_id}", connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetString(0);
            }

            connection.Close();
            return result;

        }

        public string Login(string username, string password, int location_id)
        {
            string result = "";
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new($"SELECT admin FROM Employee WHERE username = '{username}' AND location_id = {location_id} AND password = '{password}'", connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetByte(0).ToString();
            }

            connection.Close();
            return result;

        }
    }
}