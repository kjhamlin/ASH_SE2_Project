using ASHWebAPI.Models;
using ASHWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASHWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<Worker> GetEmployees()
        {
            return _employeeService.GetAllWorkers();
        }

        [HttpPut(Name = "AddEmployee")]
        public IActionResult AddEmployee(Worker worker)
        {
            try
            {
                _employeeService.AddEmployee(worker);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

            return Ok();
        }
    }
}