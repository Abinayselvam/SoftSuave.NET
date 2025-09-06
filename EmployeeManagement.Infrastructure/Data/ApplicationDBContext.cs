
using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EmployeeManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Profile> profiles { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Department> departments { get; set; }

    }

    // EmployeeRepository.cs
    //public class EmployeeRepository : IEmployeeRepository
    //{
    //    private readonly AppDbContext _context;
    //    public EmployeeRepository(AppDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<Employee> GetByIdAsync(int id)
    //    {
    //        return await _context.Employees.FindAsync(id);
    //    }
    //}

    //// SerilogExtension.cs
    //public static class SerilogExtension
    //{
    //    public static void AddSerilog(this ILoggingBuilder logging)
    //    {
    //        Log.Logger = new LoggerConfiguration()
    //            .WriteTo.Console()
    //            .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    //            .CreateLogger();

    //        logging.AddSerilog();
    //    }
    //}

}
