using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class TutorReadDTO : RegistryDTO
    {
        public int IdTutor { get; set; }
        public int IdEmployee { get; set; }
        public string EmployeeDisplayName { get; set; }
    }
}
