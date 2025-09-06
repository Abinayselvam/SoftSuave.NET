using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs.UpdateDto
{
    public class EmpUpdateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DepartmentDto Department { get; set; }
        public ProfileDto Profile { get; set; }
        public List<ProjectDto> Projects { get; set; }

    }
}
