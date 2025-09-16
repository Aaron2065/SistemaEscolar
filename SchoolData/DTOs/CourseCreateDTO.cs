using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.DTOs
{
    public class CourseCreateDTO : RegistryDTO
    {
        public int IdCourse { get; set; }
        [Required]
        public int IdGroup { get; set; }
        [Required]
        public int IdClass { get; set; }
        [Required]
        public int TeacherId { get; set; }

        public IEnumerable<StudentCourseReadDTO> IdStudentCourse { get; set; } = new List<StudentCourseReadDTO>();
    }
}
