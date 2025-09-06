using EmployeeManagement.Application.Interface.IRepo;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class ProjectRepository:IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.projects.ToListAsync();
        }
        public async Task<Project> AddProjectAsync(Project project)
        {
            var result = await _context.projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return result.Entity;

        }
        public async Task<Project> GetById(int id)
        {
            var result = await _context.projects.FindAsync(id);

            await _context.SaveChangesAsync();
            return result;

        }
        public async Task UpdateProj(Project project)
        {

            _context.projects.Update(project);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteProj(Project project)
        {
            _context.projects.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
