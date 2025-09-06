
using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Application.Interface;
using EmployeeManagement.Application.Mapping;
using EmployeeManagement.Application.Pagination;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Shared;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Application.Services
{

    public class EmpService : IEmpService
    {
        private readonly IEmpRepository _repository;
        public EmpService(IEmpRepository empRepository)
        {
            _repository = empRepository;
        }
        public async Task<ApiResponse<IEnumerable<EmployeeDto>>> GetAllEmployeesAsync()
        {
            try
            {
                var employees = await _repository.GetAllAsync();

                var employeeDtos = employees.Select(e => e.ToDto()).ToList();


                return ApiResponse<IEnumerable<EmployeeDto>>.SuccessResponse(employeeDtos, "Search results");
            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<EmployeeDto>>.FailResponse("Failed to fetch employees: " + ex.Message);
            }
        }
        public async Task<ApiResponse<EmployeeDto>> AddEmp(AddEmpDto dto)
        {
            try
            {
                var employeeEntity = new Employee
                {
                    Name=dto.Name,
                    Email=dto.Email,
                    DepartmentID=dto.DepartmentId,
                    ProfileID=dto.ProfileId,
                };

                // 2. Call repository and save
                var savedEmployee = await _repository.AddAsync(employeeEntity, dto.ProjectId);

                // 3. Map saved entity to EmployeeDto
                var createdDto = savedEmployee.ToDto();

                // 4. Return success response
                return ApiResponse<EmployeeDto>.SuccessResponse(createdDto, "Employee created successfully.");
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException?.Message ?? ex.Message;
                return ApiResponse<EmployeeDto>.FailResponse("Failed to create employee: " + msg);
            }
        }
       
        public async Task<ApiResponse<EmployeeDto>> GetEmployeeByIdAsync(int id)
        {
            try
            {
                var employee = await _repository.GetByIdAsync(id);
                if (employee == null)
                    return ApiResponse<EmployeeDto>.FailResponse("Employee not found.");

                return ApiResponse<EmployeeDto>.SuccessResponse(employee.ToDto(), "Employee found");
            }
            catch (Exception ex)
            {
                return ApiResponse<EmployeeDto>.FailResponse("Failed to fetch employee: " + ex.Message);
            }
        }
        public async Task<ApiResponse<EmployeeDto>> UpdateEmp(int id, AddEmpDto dto)
        {
            try
            {
                var employeeEntity = dto.ToEntity();
                employeeEntity.EmployeeId = id;

                var updatedEmployee = await _repository.UpdateAsync(employeeEntity, dto.ProjectId ?? new List<int>());
                if (updatedEmployee == null)
                    return ApiResponse<EmployeeDto>.FailResponse("Employee not found.");

                return ApiResponse<EmployeeDto>.SuccessResponse(updatedEmployee.ToDto(), "Employee updated successfully.");
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException?.Message ?? ex.Message;
                return ApiResponse<EmployeeDto>.FailResponse("Failed to update employee: " + msg);
            }
        }

        public async Task<ApiResponse<bool>> DeleteEmp(int id)
        {
            try
            {
                var deleted = await _repository.DeleteAsync(id);
                if (!deleted)
                    return ApiResponse<bool>.FailResponse("Employee not found.");

                return ApiResponse<bool>.SuccessResponse(true, "Employee deleted successfully.");
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException?.Message ?? ex.Message;
                return ApiResponse<bool>.FailResponse("Failed to delete employee: " + msg);
            }
        }

        public async Task<ApiResponse<PagedResultDto<EmployeeDto>>> SearchEmployeesAsync(
         string name, string departmentName, string projectName, string phone, int pageNumber, int pageSize, string sortBy = "Name")
        {
            // 1. Get queryable from repo with filters applied
            var query = _repository.SearchEmployees(name, departmentName, projectName, phone); // IQueryable<Employee>

            // 2. Optional sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                query = sortBy switch
                {
                    "Name" => query.OrderBy(e => e.Name),
                    "Email" => query.OrderBy(e => e.Email),
                    _ => query.OrderBy(e => e.EmployeeId)
                };
            }

            // 3. Get total count before pagination
            var totalCount = await query.CountAsync();

            // 4. Apply pagination
            var pagedEmployees = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // 5. Map to DTOs
            var employeesDto = pagedEmployees.Select(e => e.ToDto()).ToList();

            // 6. Wrap in response
            var paginatedResult = new PagedResultDto<EmployeeDto>
            {
                Items = employeesDto,
                Pagination = new PaginationMetadata
                {
                    Page = pageNumber,
                    PageSize = pageSize,
                    TotalRecords = totalCount,
                    TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
                    SortBy = sortBy
                }
            };

            // 7. Return ApiResponse
            return new ApiResponse<PagedResultDto<EmployeeDto>>
            {
                Success = true,
                Message = employeesDto.Any() ? "Successfully found data" : "No data found",
                Data = paginatedResult
            };
        }


    }
}

    
       
