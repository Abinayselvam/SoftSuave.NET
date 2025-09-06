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

    public class DeptRepository : IDeptRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public DeptRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Department>> GetAllDept()
        {
            return await _dbContext.departments.ToListAsync();
        }
        public async Task<Department> AddDept(Department dept)
        {
            var result = await _dbContext.departments.AddAsync(dept);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Department> GetById(int id)
        {
            var result = await _dbContext.departments.FindAsync(id);

            await _dbContext.SaveChangesAsync();
            return result;

        }
        public async Task UpdateDept(Department dept)
        {

            _dbContext.departments.Update(dept);
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteDept(Department dept)
        {
            _dbContext.departments.Remove(dept);
            await _dbContext.SaveChangesAsync();
        }
    }
    
}
