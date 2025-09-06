using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Interface.IRepo
{
    public interface IProfileRepository
    {
        Task<IEnumerable<Profile>> GetAllProfile();
        Task<Profile> AddProfileAsync(Profile profile);
        Task<Profile> GetById(int id);
        Task UpdateProf(Profile profile);
        Task DeleteProf(Profile profile);

    }
}
