using DemoApp.BusinessLogic;
using DemoApp.DataLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Text.Json;

namespace DemoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<ProductController> _logger;

        // Constructors
        public ProductController(IRepository repository, ILogger<ProductController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProductsAsync()
        {
            List<Product> products;
            try
            {
                products = await _repository.GetAllProducts();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting list of products.");
                return StatusCode(500);
            }
            return products;
        }
        [HttpGet("{input}")]
        public async Task<ActionResult<List<Product>>> GetProductAsync(string input)
                {
                    List<Product> products;
                    try
                    {
                        products = await _repository.GetProduct(input);
                    }
                    catch (SqlException ex)
                    {
                        _logger.LogError(ex, $"SQL error while getting products with name of: {input}");
                        return StatusCode(500);
                    }
                    return products;
                }
            }
}
