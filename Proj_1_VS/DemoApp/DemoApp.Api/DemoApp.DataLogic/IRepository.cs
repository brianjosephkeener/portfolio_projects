using DemoApp.BusinessLogic;

namespace DemoApp.DataLogic
{
    public interface IRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetCustomer(string input);

        Task<Location> GetLocation(int id);
        Task<List<Location>> GetAllLocations();
        
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProduct(string input);

        Task<List<Employee>> GetEmployee(string input);
        Task<List<Employee>> GetAllEmployees();
    }
}