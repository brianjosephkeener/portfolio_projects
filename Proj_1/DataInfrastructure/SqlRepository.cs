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

        public List<Room> GetAllRooms(int location_id_input)
        {
            List<Room> result = new List<Room>();
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new($"SELECT * FROM Room WHERE location_id = {location_id_input}", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string description = "No description available";
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int amount = reader.GetInt32(2);
                decimal price = reader.GetDecimal(3);
                if(!reader.IsDBNull(4))
                {
                    description = reader.GetString(4);
                }
                int location_id = location_id_input;
                DateTime CreatedAt = reader.GetDateTime(5);
                DateTime UpdatedAt = reader.GetDateTime(6);
                result.Add(new Room (id, name, amount, price, description, location_id, CreatedAt, UpdatedAt));
            }

            connection.Close();
            return result;
        }

        public Guest ViewGuest(int id, int location_id)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new($"SELECT * FROM Guest WHERE location_id = {location_id} AND id = {id}", connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                string first_name = reader.GetString(1);
                string last_name = reader.GetString(2);
                string room = reader.GetString(3);
                decimal credit = reader.GetDecimal(4);
                string confirmation_number = reader.GetString(5);
                int durationofstay = reader.GetInt32(6);
                byte checked_in = reader.GetByte(7);
                DateTime created_at = reader.GetDateTime(8);
                DateTime updated_at = reader.GetDateTime(9);
                location_id = reader.GetInt32(10);
                int room_id = reader.GetInt32(11);
                Guest guest = new Guest(id, first_name, last_name, room, location_id, room_id, created_at, updated_at, checked_in, durationofstay, credit, confirmation_number);
                return guest;                
            }
            return new Guest(1, "ERROR", "ERROR", "ERROR", 1, 1, DateTime.UtcNow, DateTime.UtcNow, 0, 0, 0.0M, "ERROR");
        }

        public string GetLocation(int id)
        {
            string result = "";
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();

            using SqlCommand cmd = new($"SELECT name FROM Location WHERE id = {id}", connection);

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                result = reader.GetString(0);
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

        public bool RegisterGuest(string confirmation_number, string first_name, string last_name, string room, decimal credit, int durationofstay, byte checked_in, int location_id, int room_id)
        {
            string confirm_result = "";
            using SqlConnection connection = new SqlConnection(this._connectionString);
            connection.Open();
            using SqlCommand cmd = new($"SELECT confirmation_number FROM Guest WHERE confirmation_number = '{confirmation_number}'", connection);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                confirm_result = reader.GetString(0);
            }
            connection.Close();
            if(confirm_result == "")
            {
                int amount_result = 0;
                decimal price_result = 0.0M;
                connection.Open();
                using SqlCommand cmd2 = new SqlCommand($"SELECT amount, price FROM Room WHERE id = {room_id} AND location_id = {location_id}", connection);
                using SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    amount_result = reader2.GetInt32(0);
                    price_result = reader2.GetDecimal(1);
                }
                connection.Close();
                if(amount_result == 0 || (price_result * durationofstay) > credit)
                {
                    return false;
                }
                else
                {
                    string systime = "SYSDATETIME()";
                    connection.Open();
                    using SqlCommand cmd3 = new($"INSERT INTO GUEST (first_name, last_name, room, credit, confirmation_number, durationofstay, checked_in, location_id, room_id) VALUES ('{first_name}', '{last_name}', '{room}', {(Convert.ToDecimal(credit-(price_result*durationofstay)))}, '{confirmation_number}', {durationofstay}, {checked_in}, {location_id}, {room_id});", connection);
                    using SqlDataReader reader3 = cmd3.ExecuteReader();
                    connection.Close();
                    connection.Open();
                    using SqlCommand cmd4 = new SqlCommand($"UPDATE Room SET amount = {amount_result-1}, updated_at = {systime} WHERE id = {room_id} AND location_id = {location_id};", connection);
                    using SqlDataReader reader4 = cmd4.ExecuteReader();
                    connection.Close();
                    return true;
                }
            }
            return false;
    }

    public List<Guest> GuestLookUp(string input, int location_id)
    {
        List<Guest> result = new List<Guest>();
        using SqlConnection connection = new SqlConnection(this._connectionString);
        connection.Open();
        byte t = 1;
        byte f = 0;
        using SqlCommand cmd = new($"SELECT * FROM Guest WHERE (room = '{input}' AND location_id = {location_id}) OR (first_name = '{input}' AND location_id = {location_id}) OR (last_name = '{input}' AND location_id = {location_id}) OR (confirmation_number = '{input}' AND location_id = {location_id});", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string first_name = reader.GetString(1);
            string last_name = reader.GetString(2);
            string room = reader.GetString(3);
            decimal credit = reader.GetDecimal(4);
            string confirmation_number = reader.GetString(5);
            int durationofstay = reader.GetInt32(6);
            byte checked_in = reader.GetByte(7);
            DateTime CreatedAt = reader.GetDateTime(8);
            DateTime UpdatedAt = reader.GetDateTime(9);
            int Location_id = reader.GetInt32(10);
            int room_id = reader.GetInt32(11);
            result.Add(new Guest (id, first_name, last_name, room, Location_id, room_id, CreatedAt, UpdatedAt, checked_in, durationofstay, credit, confirmation_number));
        }
        return result;
    }

    public List<Guest> GuestAll(int location_id)
    {
        List<Guest> result = new List<Guest>();
        using SqlConnection connection = new SqlConnection(this._connectionString);
        connection.Open();
        using SqlCommand cmd = new($"SELECT * FROM Guest WHERE location_id = {location_id};", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read())
        {
            int id = reader.GetInt32(0);
            string first_name = reader.GetString(1);
            string last_name = reader.GetString(2);
            string room = reader.GetString(3);
            decimal credit = reader.GetDecimal(4);
            string confirmation_number = reader.GetString(5);
            int durationofstay = reader.GetInt32(6);
            byte checked_in = reader.GetByte(7);
            DateTime CreatedAt = reader.GetDateTime(8);
            DateTime UpdatedAt = reader.GetDateTime(9);
            int Location_id = reader.GetInt32(10);
            int room_id = reader.GetInt32(11);
            result.Add(new Guest (id, first_name, last_name, room, Location_id, room_id, CreatedAt, UpdatedAt, checked_in, durationofstay, credit, confirmation_number));
        }
        return result;
    }

        public void EditGuest(int id, string confirmation_number, string first_name, string last_name, string room, decimal credit, int durationofstay, int location_id, int room_id)
        {
        using SqlConnection connection = new SqlConnection(this._connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand($"UPDATE Guest SET first_name = '{first_name}', last_name = '{last_name}', room = '{room}', credit = {credit}, durationofstay = {durationofstay}, updated_at = SYSDATETIME(), room_id = {room_id} WHERE id = {id}", connection);
        using SqlDataReader reader = cmd.ExecuteReader();
    }

}
}