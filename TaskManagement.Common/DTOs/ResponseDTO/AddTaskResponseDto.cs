using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Common.DTOs.ResponseDTO
{
    public class AddTaskResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedUserId { get; set; }
    }
}
