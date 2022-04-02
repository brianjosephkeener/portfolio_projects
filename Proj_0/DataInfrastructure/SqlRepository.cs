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
    }
}