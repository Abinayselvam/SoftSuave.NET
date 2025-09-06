using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Data.Entities
{
    [Table("Project")]
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation property
        public List<TaskItem> Tasks { get; set; }
    }
}
