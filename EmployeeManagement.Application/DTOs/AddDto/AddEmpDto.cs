using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs.AddDto
{
    public class AddEmpDto
    {
        //public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int ProfileId { get; set; }
        public List<int> ProjectId { get; set; }

    }
}
