using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoApp.UI;
using DemoApp.UI.DTOs;
using Xunit;

namespace DemoApp.ConApp
{
    public class ConAppTest
    {
        private readonly CustomerDTO customer = new CustomerDTO("Test", "West", "13.99", "x1 Melon", 1);
        public List<CustomerDTO> customerList = new List<CustomerDTO>();

        [Fact]
        public void FactOne()
        {
            Assert.IsType<HttpClient>(IO.httpClient);
            Assert.Equal(1, 1);
        }
        [Fact]
        public void FactTwo()
        {
            Assert.StartsWith(customer.first_name, "Test");
        }
        [Fact]
        public void FactThree()
        {
            customerList.Add(customer);
            Assert.Single(customerList);
        }
    }
}
