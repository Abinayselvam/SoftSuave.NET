using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interface.IService
{
    public interface IProjectService
    {
        Task<ApiResponse<IEnumerable<ProjectDto>>> GetAllProject();
        Task<ApiResponse<ProjectDto>> AddProject(AddProjDto dto);
        Task<ApiResponse<ProjectDto>> GetById(int id);
        Task<ApiResponse<ProjectDto>> UpdateProject(AddProjDto dto, int id);
        Task<ApiResponse<ProjectDto>> DeleteProject(int dto);

    }
}
