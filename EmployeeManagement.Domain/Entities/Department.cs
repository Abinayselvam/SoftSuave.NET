using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace EmployeeManagement.Domain.Entities
{
    public class Department
{
    [Key]
    public int DepartmentID { get; set; }

    [Required]
    public string DeptName { get; set; }

    // One-to-many relationship with Employee
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}

  
}
