using EmployeeManagement.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Domain.Entities
{

    public class Profile
{
    [Key]
    public int ProfileID { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string Address { get; set; }

    // One-to-one relationship with Employee
    public Employee Employee { get; set; }  // One-to-one relationship with Employee
}

}
