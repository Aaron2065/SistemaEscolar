using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.DTOs
{
    public class TeacherReadDTO : RegistryDTO
    {
        public int IdTeacher { get; set; }
        public int IdEmployee { get; set; }

        public string GroupDisplayName { get; set; } 
    }
}
