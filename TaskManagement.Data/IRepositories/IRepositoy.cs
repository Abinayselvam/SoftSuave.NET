using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.IRepositories
{
    public class IRepositoy
    {
        public interface IRepository<T> where T : class
        {
            Task<T> AddAsync(T entity);
            Task<IEnumerable<T>> GetAllAsync();
            Task<T?> GetByIdAsync(int id);
            Task UpdateAsync(T entity);
            Task DeleteAsync(T entity);
        }

    }
}
