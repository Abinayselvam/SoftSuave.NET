using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Context;
using TaskManagement.Data.Entities;
using TaskManagement.Data.IRepositories;

namespace TaskManagement.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Project> AddAsync(Project entity)
        {
            _context.Projects.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
        public async Task UpdateAsync(Project entity)
        {
            _context.Projects.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Project entity)
        {
            _context.Projects.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Project>> GetActiveProjectsAsync()
        {
            return await _context.Projects
                                 .Where(p => p.IsActive)  // assuming Project has IsActive property
                                 .ToListAsync();
        }
    }

}
