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
    }
}