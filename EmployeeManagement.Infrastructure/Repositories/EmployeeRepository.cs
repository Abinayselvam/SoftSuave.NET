using EmployeeManagement.Application.Interface;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmpRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.employees
                .Include(e => e.Department)
                .Include(e => e.Profile)
                .Include(e => e.Projects)
                .ToListAsync();
        }
        // Add employee
        public async Task<Employee> AddAsync(Employee employee, List<int> projectIds)
        {
            var existingProjects = await _context.projects
            .Where(p => projectIds.Contains(p.ProjectID))
            .ToListAsync();

          
            employee.Projects = existingProjects;

            var result = await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return await _context.employees
                 .Include(e => e.Department)
                .Include(e => e.Profile)
                .Include(e => e.Projects)
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId); 
        }
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.employees
                .Include(e => e.Department)
                .Include(e => e.Profile)
                .Include(e => e.Projects)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }
       
        public async Task<Employee?> UpdateAsync(Employee employee, List<int> projectIds)
        {
            var existingEmployee = await _context.employees
              .Include(e => e.Projects)
                .Include(e => e.Department)
                .Include(e => e.Profile)
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);


            if (existingEmployee == null)
                return null;

            // Update scalar fields
            existingEmployee.Name = employee.Name;
            existingEmployee.DepartmentID = employee.DepartmentID;
            existingEmployee.ProfileID= employee.ProfileID;

            // Update projects
            var existingProjects = await _context.projects
                .Where(p => projectIds.Contains(p.ProjectID))
                .ToListAsync();

            existingEmployee.Projects = existingProjects;

            await _context.SaveChangesAsync();
            return existingEmployee;
        }

       
        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee == null)
                return false;

            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }
        //searchapi method
        public IQueryable<Employee> SearchEmployees(string employeeName, string departmentName, string projectName, string phone)
        {
            var query = _context.employees
                .Include(e => e.Department)
                .Include(e => e.Profile)
                .Include(e => e.Projects)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(employeeName))
            {
                query = query.Where(e => e.Name == employeeName);
            }

            if (!string.IsNullOrWhiteSpace(departmentName))
            {
                query = query.Where(e =>  e.Department.DeptName == departmentName);
            }

            if (!string.IsNullOrWhiteSpace(projectName))
            {
                query = query.Where(e =>  e.Projects.Any(p => p.ProjectName == projectName));
            }
            if (!string.IsNullOrWhiteSpace(phone))
            {
                query = query.Where(e => e.Profile != null && e.Profile.Phone == phone);
            }
            return query;
        }


    }
}


