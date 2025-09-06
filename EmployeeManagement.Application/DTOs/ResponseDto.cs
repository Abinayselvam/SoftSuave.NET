
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.DTOs
{
    public class ResponseDto<T>
    {
        public List<T> Items { get; set; }
       // public PaginationDto Page { get; set; }
    }
}
