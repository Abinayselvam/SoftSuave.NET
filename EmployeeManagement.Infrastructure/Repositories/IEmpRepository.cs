using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interface
{
  public interface IEmpRepository
    {
         Task<IEnumerable<Employee>> GetAllAsync();
        //Task<Employee> AddAsync(Employee employee);
        Task<Employee> AddAsync(Employee employee, List<int> projectIds);
        // GET by Id
        Task<Employee?> GetByIdAsync(int id);
        // UPDATE employee with projects
        Task<Employee?> UpdateAsync(Employee employee, List<int> projectIds);
        // DELETE employee
        Task<bool> DeleteAsync(int id);
        IQueryable<Employee> SearchEmployees(string employeeName, string departmentName, string projectName, string phoneNumber);

    }
}
