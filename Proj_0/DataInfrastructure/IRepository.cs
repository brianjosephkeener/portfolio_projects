using System;
using Proj_0.Models;

namespace Proj_0.Data
{
    public interface IRepository
    {
        List<Employee> GetAllEmployees();
    }
}