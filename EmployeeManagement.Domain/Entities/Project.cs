using EmployeeManagement.Domain.Entities;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeManagement.Domain.Entities
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        // Many-to-many relationship with Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}


