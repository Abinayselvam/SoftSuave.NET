using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs.UpdateDto
{
    public class UpdateProfDto
    {
        public int ProfileID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // One-to-one relationship with Employee
    }
}
