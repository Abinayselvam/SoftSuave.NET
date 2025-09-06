using EmployeeManagement.Application.Interface;
using EmployeeManagement.Application.Interface.IRepo;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProfileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Profile>> GetAllProfile()
        {
            return await _dbContext.profiles.ToListAsync();
        }
        public async Task<Profile> AddProfileAsync(Profile profile)
        {
            var result = await _dbContext.profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Profile> GetById(int id)
        {
            var result=await _dbContext.profiles.FindAsync(id);

            await _dbContext.SaveChangesAsync();
            return result;
           
        }
        public async Task UpdateProf(Profile profile)
        {

             _dbContext.profiles.Update(profile);
            await _dbContext.SaveChangesAsync();
           
        }
        public async Task DeleteProf(Profile profile)
        {
            _dbContext.profiles.Remove(profile);
            await _dbContext.SaveChangesAsync();
        }

    }



}
