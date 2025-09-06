using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Application.Interface.IService;
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Application.DTOs.UpdateDto;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _service;
        public ProfileController(IProfileService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProfile()
        {
            return Ok( await _service.GetAllProfile());
        }
        [HttpPost]
        public async Task<IActionResult> AddProf(AddProfDto dto)
        {
            return Ok(await _service.AddProfile(dto));
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetById(id));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProf([FromBody]AddProfDto dto,int id)
        {
            return Ok(await _service.UpdateProfile(dto,id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProf(int id)
        {
            return Ok(await _service.DeleteProfile(id));
        }
    }
}
