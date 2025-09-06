using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace TaskManagement.Data.Context
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Project> Projects { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        

    }
}
