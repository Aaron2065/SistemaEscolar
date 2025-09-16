using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.DTOs
{
    public class EmployeeReadDTO
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public DateTime BornDate { get; set; }
    }
}
