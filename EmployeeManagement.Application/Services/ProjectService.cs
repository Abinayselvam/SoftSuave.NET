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
    public class ProjectService:IProjectService
    {
        private readonly IProjectRepository _repository;
        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<IEnumerable<ProjectDto>>> GetAllProject()
        {
            var profile = await _repository.GetAllProjectsAsync();
            var result = profile.Select(s => new ProjectDto
            {
                ProjectID=s.ProjectID,
                ProjectName=s.ProjectName,
                StartDate=s.StartDate,
            });
            return ApiResponse<IEnumerable<ProjectDto>>.SuccessResponse(result, "Profiles retrieved successfully.");
        }
        public async Task<ApiResponse<ProjectDto>> AddProject(AddProjDto dto)//add do
        {

            try
            {
            
                var profileEntity = new Project
                {
                  
                   ProjectName=dto.ProjectName,
                   StartDate=dto.StartDate,

                };

                // Save to DB
                var savedProject = await _repository.AddProjectAsync(profileEntity);

                // Convert to ProfileDto
                var projectDto = new ProjectDto
                {

                   ProjectID=savedProject.ProjectID,
                   StartDate=savedProject.StartDate,
                   ProjectName=savedProject.ProjectName,

                };

                return ApiResponse<ProjectDto>.SuccessResponse(projectDto, "Profile added successfully.");
            }
            catch (Exception ex)
            {
                return ApiResponse<ProjectDto>.FailResponse("Failed to add profile: " + ex.Message);
            }
        }
        public async Task<ApiResponse<ProjectDto>> GetById(int id)
        {
            var projectId = await _repository.GetById(id);
            if (projectId == null)
            {
                return ApiResponse<ProjectDto>.FailResponse("Id is not in db");
            }
            var result = new ProjectDto
            {
               ProjectID=projectId.ProjectID,
               ProjectName = projectId.ProjectName,
               StartDate = projectId.StartDate,
            };
            return ApiResponse<ProjectDto>.SuccessResponse(result, "Successfully find data");
        }
        public async Task<ApiResponse<ProjectDto>> UpdateProject(AddProjDto dto, int id)
        {
            var projectID = await _repository.GetById(id);
            if (projectID == null)
            {
                return ApiResponse<ProjectDto>.FailResponse("Data is not find");
            }
            projectID.ProjectName=dto.ProjectName;
            projectID.StartDate=dto.StartDate;  
            
            await _repository.UpdateProj(projectID);
          
            var result = new ProjectDto
            {
               ProjectID = projectID.ProjectID,
               ProjectName = dto.ProjectName,
               StartDate=dto.StartDate,
            };
            return ApiResponse<ProjectDto>.SuccessResponse(result, "Successfully update data");
        }
        public async Task<ApiResponse<ProjectDto>> DeleteProject(int Id)
        {
            var profileID = await _repository.GetById(Id);
            if (profileID == null)
            {
                return ApiResponse<ProjectDto>.FailResponse("Data not found");
            }
            await _repository.DeleteProj(profileID);
            var result = new ProjectDto
            {
               ProjectID= profileID.ProjectID,
               ProjectName=profileID.ProjectName,
               StartDate=profileID.StartDate,
            };
            return ApiResponse<ProjectDto>.SuccessResponse(result, "Successfully delete data");
        }


    }
}
