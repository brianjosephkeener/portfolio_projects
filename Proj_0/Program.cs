using System;
using Terminal.Gui;
using NStack;
using Proj_0.Models;
using Proj_0.Data;

namespace Proj_0
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionStr = "Server=tcp:brian120496.database.windows.net,1433;Initial Catalog=test_db;Persist Security Info=False;User ID=bkeener;Password=Letmein1986!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            IRepository repo = new SqlRepository(connectionStr);
            IEnumerable<Employee> employees = repo.GetAllEmployees();
            App app = new App();
        }
    }
}