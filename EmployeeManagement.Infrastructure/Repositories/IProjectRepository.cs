using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interface.IRepo
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> AddProjectAsync(Project project);
        Task<Project> GetById(int id);
        Task UpdateProj(Project project);
        Task DeleteProj(Project project);
    }
}
