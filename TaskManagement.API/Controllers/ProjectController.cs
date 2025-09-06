using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Service;
using TaskManagement.Common.DTOs.RequestDTO;
using TaskManagement.Common.DTOs.ResponseDTO;
using TaskManagement.Data.Entities;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectService _service;

        public ProjectController(ProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AddProjectResponseDTO>>> GetAll()
        {
            var projects = await _service.GetProjectsAsync();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddProjectResponseDTO>> GetById(int id)
        {
            var project = await _service.GetByIdAsync(id);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpGet("active")]
        public async Task<ActionResult<List<AddProjectResponseDTO>>> GetActive()
        {
            var projects = await _service.GetActiveProjectsAsync();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<AddProjectResponseDTO>> Create(AddProjectRequestDto dto)
        {
            var project = await _service.AddProjectAsync(dto);
            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AddProjectResponseDTO>> Update(int id, AddProjectRequestDto dto)
        {
            var project = await _service.UpdateAsync(id, dto);
            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }

}
