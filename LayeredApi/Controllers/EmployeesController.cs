using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeRepositories;
using EmployeeRepositories.Data;

namespace LayeredApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository _empRepo;
        public EmployeesController(IEmployeeRepository empRepo)
        {
            this._empRepo = empRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var empList = await _empRepo.GetEmployees();
            return Ok(empList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var empList = await _empRepo.GetEmployees();
            return Ok(empList);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee emp)
        {
            await _empRepo.InsertEmployee(emp);
            return CreatedAtAction("get", new { id = emp.EmployeeId }, emp);
        }
    }
}
