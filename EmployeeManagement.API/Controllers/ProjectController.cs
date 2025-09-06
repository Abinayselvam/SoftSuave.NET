using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Application.Interface.IService;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _service;
        public ProjectController(IProjectService service)
        {
           _service=service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            return Ok(await _service.GetAllProject());
        }
        [HttpPost]
        public async Task<IActionResult> AddProject(AddProjDto dto)
        {
            return Ok(await _service.AddProject(dto));
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProf([FromBody] AddProjDto dto, int id)
        {
            return Ok(await _service.UpdateProject(dto, id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProf(int id)
        {
            return Ok(await _service.DeleteProject(id));
        }
    }
}
