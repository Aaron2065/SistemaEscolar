using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class EmployeeReadDTO : RegistryDTO
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public DateTime BornDate { get; set; }
    }
}
