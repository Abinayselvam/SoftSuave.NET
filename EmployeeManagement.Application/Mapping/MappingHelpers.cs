using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Application.DTOs.AddDto;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;

namespace EmployeeManagement.Application.Mapping
{
    public static class MappingHelpers
    {
        // ----------- Entity to DTO -------------
        public static EmployeeDto ToDto(this Employee employee) =>
     employee == null ? null : new EmployeeDto
     {
         EmployeeId = employee.EmployeeId,
         Name = employee.Name,
         Email = employee.Email,
         Department = employee.Department?.ToDto(),
         Profile = employee.Profile?.ToDto(),
         Projects = employee.Projects?.Select(p => p.ToDto()).ToList() ?? new List<ProjectDto>() // Ensure it's not null
     };

        public static DepartmentDto ToDto(this Department dept) =>
            dept == null ? null : new DepartmentDto
            {
                DepartmentID = dept.DepartmentID,
                DeptName = dept.DeptName
            };

        public static ProfileDto ToDto(this Profile profile) =>
            profile == null ? null : new ProfileDto
            {
                ProfileID = profile.ProfileID,
                Phone = profile.Phone,
                Address = profile.Address
            };

        public static ProjectDto ToDto(this Project project) =>
            project == null ? null : new ProjectDto
            {
                ProjectID = project.ProjectID,
                ProjectName = project.ProjectName,
                StartDate = project.StartDate
            };

        // ----------- DTO to Entity -------------

        public static Employee ToEntity(this EmployeeDto dto) =>
            dto == null ? null : new Employee
            {
                EmployeeId = dto.EmployeeId,
                Name = dto.Name,
                Email = dto.Email,
                DepartmentID = dto.Department?.DepartmentID ?? 0,
                ProfileID = dto.Profile?.ProfileID ?? 0,
                Projects = dto.Projects?.Select(p => new Project { ProjectID = p.ProjectID }).ToList() ?? new List<Project>()
            };

        public static Department ToEntity(this DepartmentDto dto) =>
            dto == null ? null : new Department
            {
                DepartmentID = dto.DepartmentID,
                DeptName = dto.DeptName
            };

        public static Profile ToEntity(this ProfileDto dto) =>
            dto == null ? null : new Profile
            {
                ProfileID = dto.ProfileID,
                Phone = dto.Phone,
                Address = dto.Address
            };

        public static Project ToEntity(this ProjectDto dto) =>
             dto ==null?null: new Project
            {
               ProjectID = dto.ProjectID,
               ProjectName = dto.ProjectName,
               StartDate=dto.StartDate,
            };

    // ------- AddEmpDto to Entity (without DbContext) --------

    public static Employee ToEntity(this AddEmpDto dto) =>
            dto == null ? null : new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                DepartmentID = dto.DepartmentId,
                ProfileID = dto.ProfileId
                // Projects are assigned in the repository
            };

        // ------- AddEmpDto to Entity (with DbContext, optional) --------

        public static async Task<Employee> ToEntity(this AddEmpDto dto, ApplicationDbContext context)
        {
            if (dto == null) return null;

            var employee = new Employee
            {
                Name = dto.Name,
                Email = dto.Email,
                DepartmentID = dto.DepartmentId,
                ProfileID = dto.ProfileId,
                Projects = new List<Project>()
            };

            foreach (var projectId in dto.ProjectId ?? Enumerable.Empty<int>())
            {
                var local = context.projects.Local.FirstOrDefault(p => p.ProjectID == projectId);
                var project = local ?? new Project { ProjectID = projectId };
                context.Attach(project);
                employee.Projects.Add(project);
            }

            return employee;
        }


    }

}
