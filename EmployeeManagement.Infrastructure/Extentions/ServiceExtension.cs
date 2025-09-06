using EmployeeManagement.Application.Interface;
using EmployeeManagement.Application.Interface.IRepo;
using EmployeeManagement.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.Infrastructure.Extentions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoriesAndServices(this IServiceCollection services)
        {
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IProfileRepository, ProfileRepository>();

            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IDeptService, DeptService>();
            services.AddScoped<IDeptRepository, DeptRepository>();

            services.AddScoped<IEmpService, EmpService>();
            services.AddScoped<IEmpRepository, EmployeeRepository>();
        }
    }

}
