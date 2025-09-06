using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Common.DTOs.RequestDTO
{
    public class AddProjectRequestDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
    }
}
