using System;
using Proj_1.Models;

namespace Proj_1.Data
{
    public interface IRepository
    {
        List<Employee> GetAllEmployees();
        List<Location> GetAllLocations();
        public string Login(string username, string password, int location_id);
        string FindUsername(string username, int location_id);
        public string GetLocation(int id);
        public List<Product> GetAllProducts(int location_id_input);
        public bool RegisterCustomer(string confirmation_number, string first_name, string last_name, string Product, decimal credit, int durationofstay, byte checked_in, int location_id, int Product_id);
        public List<Customer> CustomerLookUp(string input, int location_id);
        public Customer ViewCustomer(int id, int location_id);
        public void EditCustomer(int id, string confirmation_number, string first_name, string last_name, string Product, decimal credit, int durationofstay, int location_id, int Product_id);
        public List<Customer> CustomerAll(int location_id);
    }
}