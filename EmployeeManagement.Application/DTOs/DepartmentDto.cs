using EmployeeManagement.Domain.Entities;
using System.ComponentModel.DataAnnotations;


namespace EmployeeManagement.Application.DTOs
{
    public class DepartmentDto
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        public string DeptName { get; set; }

       
    }

}
