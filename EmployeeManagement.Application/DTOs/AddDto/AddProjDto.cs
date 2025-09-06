using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs.AddDto
{
    public class AddProjDto
    {
        public string ProjectName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

    }
}
