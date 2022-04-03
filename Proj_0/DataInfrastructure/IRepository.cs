using System;
using Proj_0.Models;

namespace Proj_0.Data
{
    public interface IRepository
    {
        List<Employee> GetAllEmployees();
        List<Location> GetAllLocations();
        public string Login(string username, string password, int location_id);
        string FindUsername(string username, int location_id);
        public string GetLocation(int id);
        public List<Room> GetAllRooms(int location_id_input);
        public bool RegisterGuest(string confirmation_number, string first_name, string last_name, string room, decimal credit, int durationofstay, byte checked_in, int location_id, int room_id);
    }
}