using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Data.Entities;
using static TaskManagement.Data.IRepositories.IRepositoy;

namespace TaskManagement.Data.IRepositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        // Example: additional method
        Task<IEnumerable<Project>> GetActiveProjectsAsync();
    }
}
    //public interface IProjectRepository
    //{
    //    //Task AddAsync(Project project);
    //    //Task<Project?> GetById(int id);
    //    //Task<List<Project>> GetAllAsync();
    //    //Task Update(Project project);
    //    //Task Delete(Project project);
    //}

