using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Application.Interface;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpService _service;

        public EmployeeController(IEmpService service)
        {
            _service = service;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            return Ok(await _service.GetAllEmployeesAsync());
                
        }
        //// POST: api/Employee
        [HttpPost]
       
        public async Task<IActionResult> AddEmployee(AddEmpDto dto)
        {
            return Ok(await _service.AddEmp(dto));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var response = await _service.GetEmployeeByIdAsync(id);
            return Ok(response);
        }
      
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] AddEmpDto dto)
        {
            var response = await _service.UpdateEmp(id, dto);
            return Ok(response);
        }
     
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = await _service.DeleteEmp(id);
            return Ok(response);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchEmployees(
      
          [FromQuery] string? name = null,
            [FromQuery] string? departmentName = null,
            [FromQuery] string? projectName = null,
            [FromQuery] string? phone = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Name")
        {
            var result = await _service.SearchEmployeesAsync(name, departmentName, projectName, phone, pageNumber, pageSize, sortBy);
            return Ok(result);
        }


    }


}

