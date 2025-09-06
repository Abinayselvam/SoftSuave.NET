using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Application.DTOs.UpdateDto;
using EmployeeManagement.Application.Interface.IRepo;
using EmployeeManagement.Application.Interface.IService;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;
        public ProfileService(IProfileRepository profileRepository)
        {
            _repository = profileRepository;
        }

        public async Task<ApiResponse<IEnumerable<ProfileDto>>> GetAllProfile()
        {
            var profile = await _repository.GetAllProfile();
            var result = profile.Select(s => new ProfileDto
            {
                ProfileID=s.ProfileID,
                Address = s.Address,
                Phone = s.Phone,
            });
            return ApiResponse<IEnumerable<ProfileDto>>.SuccessResponse(result, "Profiles retrieved successfully.");
        }
        public async Task<ApiResponse<ProfileDto>> AddProfile(AddProfDto dto)//add do
        {

            try
            {
                // Map AddProfDto to entity manually
                var profileEntity = new Profile
                {
                    Phone = dto.Phone,
                    Address = dto.Address,

                };

                // Save to DB
                var savedProfile = await _repository.AddProfileAsync(profileEntity);

                // Convert to ProfileDto
                var profileDto = new ProfileDto
                {
                    ProfileID = savedProfile.ProfileID,
                    Phone = savedProfile.Phone,
                    Address = savedProfile.Address,

                };

                return ApiResponse<ProfileDto>.SuccessResponse(profileDto, "Profile added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<ProfileDto>.FailResponse("Failed to add profile: " + ex.Message);
            }
        }
        public async Task<ApiResponse<ProfileDto>> GetById(int id)
        {
            var profileId = await _repository.GetById(id);
            if (profileId == null)
            {
                return ApiResponse<ProfileDto>.FailResponse("Id is not in db");
            }
            var result = new ProfileDto
            {
                ProfileID = profileId.ProfileID,
                Phone = profileId.Phone,
                Address = profileId.Address,
            };
            return ApiResponse<ProfileDto>.SuccessResponse(result, "Successfully find data");
        }
        public async Task<ApiResponse<ProfileDto>> UpdateProfile(AddProfDto dto, int id  )
        {
            var profileID= await _repository.GetById(id);
            if(profileID == null)
            {
                return ApiResponse<ProfileDto>.FailResponse("Data is not find");
            }
            
            profileID.Phone = dto.Phone;
            profileID.Address = dto.Address;

             await _repository.UpdateProf(profileID);
            //var updateprof=await _repository.GetById(id);
            var result = new ProfileDto
            {
                ProfileID = profileID.ProfileID,
                Phone = profileID.Phone,
                Address = profileID.Address,
            };
            return ApiResponse<ProfileDto>.SuccessResponse(result, "Successfully update data");
        }
        public async Task<ApiResponse<ProfileDto>> DeleteProfile(int Id)
        {
            var profileID=await _repository.GetById(Id);
            if (profileID==null)
            {
                return ApiResponse<ProfileDto>.FailResponse("Data not found");
            }
            await _repository.DeleteProf(profileID);
            var result = new ProfileDto
            {
                ProfileID=profileID.ProfileID,
                Phone=profileID.Phone,
                Address=profileID.Address,
            };
            return ApiResponse<ProfileDto>.SuccessResponse(result,"Successfully delete data");
        }
        
    }
}



