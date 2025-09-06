using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities
{

    public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    public string Name { get; set; }

    [EmailAddress]
    [Required]
    public string Email { get; set; }

    public int DepartmentID { get; set; }
    public int ProfileID { get; set; }

    // Foreign key relationships
    [ForeignKey("DepartmentID")]
    public Department Department { get; set; }

    [ForeignKey("ProfileID")]
    public Profile Profile { get; set; }

    // Many-to-many relationship with Project
    public ICollection<Project> Projects { get; set; } 
}

}
