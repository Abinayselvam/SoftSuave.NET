using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Application.Interface.IRepo;
using EmployeeManagement.Application.Interface.IService;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Repositories;
using EmployeeManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services
{
    public class DeptService : IDeptService
    {
        private readonly IDeptRepository _repository;
        public DeptService(IDeptRepository deptRepository)
        {
            _repository = deptRepository;
        }

        public async Task<ApiResponse<IEnumerable<DepartmentDto>>> GetAllDept()
        {
            var dept = await _repository.GetAllDept();
            var result = dept.Select(s => new DepartmentDto
            {
              DepartmentID=s.DepartmentID,
               DeptName=s.DeptName,
            });
            return ApiResponse<IEnumerable<DepartmentDto>>.SuccessResponse(result, "Profiles retrieved successfully.");
        }
        public async Task<ApiResponse<DepartmentDto>> AddDept(AddDeptDto dto)//add do
        {

            try
            {
                // Map AddProfDto to entity manually
                var deptEntity = new Department
                {
                   DeptName = dto.DeptName,
                   

                };

                // Save to DB
                var savedDept = await _repository.AddDept(deptEntity);

                // Convert to ProfileDto
                var deptDto = new DepartmentDto
                {
                   DepartmentID=savedDept.DepartmentID,
                   DeptName=dto.DeptName,   

                };

                return ApiResponse<DepartmentDto>.SuccessResponse(deptDto, "Profile added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<DepartmentDto>.FailResponse("Failed to add profile: " + ex.Message);
            }
        }
        public async Task<ApiResponse<DepartmentDto>> GetById(int id)
        {
            var deptId = await _repository.GetById(id);
            if (deptId == null)
            {
                return ApiResponse<DepartmentDto>.FailResponse("Id is not in db");
            }
            var result = new DepartmentDto
            {
               DepartmentID=deptId.DepartmentID,
               DeptName=deptId.DeptName,
            };
            return ApiResponse<DepartmentDto>.SuccessResponse(result, "Successfully find data");
        }
        public async Task<ApiResponse<DepartmentDto>> UpdateDept(AddDeptDto dto, int id)
        {
            var deptID = await _repository.GetById(id);
            if (deptID == null)
            {
                return ApiResponse<DepartmentDto>.FailResponse("Data is not find");
            }

           deptID.DeptName = dto.DeptName; 
            

            await _repository.UpdateDept(deptID);
            //var updateprof=await _repository.GetById(id);
            var result = new DepartmentDto
            {
                DepartmentID = deptID.DepartmentID,
                DeptName=dto.DeptName,
            };
            return ApiResponse<DepartmentDto>.SuccessResponse(result, "Successfully update data");
        }
        public async Task<ApiResponse<DepartmentDto>> DeleteDept(int Id)
        {
            var deptID = await _repository.GetById(Id);
            if (deptID == null)
            {
                return ApiResponse<DepartmentDto>.FailResponse("Data not found");
            }
            await _repository.DeleteDept(deptID);
            var result = new DepartmentDto
            {
               DepartmentID= deptID.DepartmentID,
               DeptName=deptID.DeptName,
            };
            return ApiResponse<DepartmentDto>.SuccessResponse(result, "Successfully delete data");
        }
    }

}
