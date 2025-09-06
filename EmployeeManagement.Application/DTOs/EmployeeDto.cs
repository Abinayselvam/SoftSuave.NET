using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs
{
    public class EmployeeDto
    {
        
        public int EmployeeId { get; set; }
        public string Name { get; set; }
       
        public string Email { get; set; }
        public DepartmentDto Department { get; set; }
        public ProfileDto Profile { get; set; }
        public List<ProjectDto> Projects { get; set; }
    }
}
