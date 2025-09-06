using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Shared;
namespace EmployeeManagement.Application.Interface.IService
{
    public interface IDeptService
    {
        Task<ApiResponse<IEnumerable<DepartmentDto>>> GetAllDept();
        Task<ApiResponse<DepartmentDto>> AddDept(AddDeptDto dto);
        Task<ApiResponse<DepartmentDto>> GetById(int id);
        Task<ApiResponse<DepartmentDto>> UpdateDept(AddDeptDto dto, int id);
        Task<ApiResponse<DepartmentDto>> DeleteDept(int dto);
    }
}
