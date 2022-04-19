using DemoApp.BusinessLogic;

namespace DemoApp.DataLogic
{
    public interface IRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetCustomer(string input);
        Task CreateCustomer(Customer customer);

        Task<List<Customer>> GetLocationCustomers(int input);
        Task<List<Location>> GetAllLocations();
        
        Task<List<Product>> GetAllProducts(string input);
        Task<List<Product>> GetProduct(string input);
        Task Purchase(List<Product> products);

        Task<List<Employee>> GetEmployee(string input);
        Task<List<Employee>> GetAllEmployees();

    }
}