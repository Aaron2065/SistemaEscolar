using SchoolData.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class CourseReadDTO : RegistryDTO
    {
        public int IdCourse { get; set; }

        public int IdGroup { get; set; }
        public string GroupDisplayName { get; set; } // Por ejemplo: "3-A"

        public int IdClass { get; set; }
        public string ClassName { get; set; }

        public int TeacherId { get; set; }
        public string TeacherName { get; set; } // Ahora viene del Employee
    }
}
