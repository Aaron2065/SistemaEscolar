using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class TeacherReadDTO : RegistryDTO
    {
        public int IdTeacher { get; set; }
        public int IdEmployee { get; set; }
    }
}
