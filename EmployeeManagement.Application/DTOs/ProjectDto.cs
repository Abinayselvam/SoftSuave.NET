
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Application.DTOs
{
    public class ProjectDto
    {
        public int ProjectID { get; set; }
      
        public string ProjectName { get; set; }

        public DateTime StartDate { get; set; }
       

    }
}
