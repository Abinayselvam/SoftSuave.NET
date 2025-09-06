using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Shared;

namespace EmployeeManagement.Application.Interface
{
    public interface IEmpService
    {
        Task<ApiResponse<IEnumerable<EmployeeDto>>> GetAllEmployeesAsync();
        Task<ApiResponse<EmployeeDto>> AddEmp(AddEmpDto dto);

        // GET employee by ID
        Task<ApiResponse<EmployeeDto>> GetEmployeeByIdAsync(int id);

        // UPDATE employee
        Task<ApiResponse<EmployeeDto>> UpdateEmp(int id, AddEmpDto dto);

        // DELETE employee
        Task<ApiResponse<bool>> DeleteEmp(int id);
        Task<ApiResponse<PagedResultDto<EmployeeDto>>> SearchEmployeesAsync(
    string name, string departmentName, string projectName, string phone, int pageNumber, int pageSize, string sortBy = "Name");
        //

    }
}
