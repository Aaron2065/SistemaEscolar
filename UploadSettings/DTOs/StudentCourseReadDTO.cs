using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class StudentCourseReadDTO : RegistryDTO
    {
        public int IdStudent { get; set;}
        public int IdCourse { get; set;}
    }
}
