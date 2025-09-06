using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs
{
    public class ProfileDto
    {
        
        public int ProfileID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

  
        
    }
}
