using EmployeeManagement.Domain.Entities;
namespace EmployeeManagement.Infrastructure.Repositories
{
    public interface IDeptRepository
    {
        Task<IEnumerable<Department>> GetAllDept();
        Task<Department> AddDept(Department profile);
        Task<Department> GetById(int id);
        Task UpdateDept(Department profile);
        Task DeleteDept(Department profile);

    }
}
