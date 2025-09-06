using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Application.Interface;
using EmployeeManagement.Application.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : Controller
    {
        private readonly IDeptService _service;
        public DepartmentController(IDeptService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            return Ok(await _service.GetAllDept());
        }
        [HttpPost]
        public async Task<IActionResult> AddDept(AddDeptDto dto)
        {
            return Ok(await _service.AddDept(dto));
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDept([FromBody] AddDeptDto dto, int id)
        {
            return Ok(await _service.UpdateDept(dto, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDept(int id)
        {
            return Ok(await _service.DeleteDept(id));
        }
    }
}
