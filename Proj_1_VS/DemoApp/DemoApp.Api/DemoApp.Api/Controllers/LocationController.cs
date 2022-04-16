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
    public class LocationController : ControllerBase
    {
        // Fields
        private readonly IRepository _repository;
        private readonly ILogger<CustomerController> _logger;

        // Constructors
        public LocationController(IRepository repository, ILogger<CustomerController> logger)
        {
            this._repository = repository;
            this._logger = logger;
        }

        // Methods
        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetAllLocationsAsync()
        {
            List<Location> locations;
            try
            {
                locations = await _repository.GetAllLocations();
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "SQL error while getting location list.");
                return StatusCode(500);
            }
            return locations;
        }
        [HttpGet("{input}")]
        public async Task<ActionResult<Location>> GetLocationAsync(string input)
                {
                    Location location;
                    try
                    {
                        location = await _repository.GetLocation(Int32.Parse(input));
                    }
                    catch (SqlException ex)
                    {
                        _logger.LogError(ex, $"SQL error while getting location: {input}.");
                        return StatusCode(500);
                    }
                    return location;
                }
            }
}
