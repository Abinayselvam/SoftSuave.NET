using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Application.DTOs.UpdateDto;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interface.IService
{
    public interface IProfileService
    {
        Task<ApiResponse<IEnumerable<ProfileDto>>> GetAllProfile();
        Task<ApiResponse<ProfileDto>> AddProfile(AddProfDto dto);
        Task<ApiResponse<ProfileDto>> GetById(int id);
        Task<ApiResponse<ProfileDto>> UpdateProfile(AddProfDto dto,int id);
        Task<ApiResponse<ProfileDto>> DeleteProfile(int dto);

    }
}
