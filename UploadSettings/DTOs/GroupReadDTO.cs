using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class GroupReadDTO : RegistryDTO
    {
        public int IdGradeGroup { get; set; }
        public int Grade { get; set; }
        public string GroupClass { get; set; }
        public int IdTutor { get; set; }
        public string TutorName { get; set; } // opcional para mostrar nombre del tutor
        public IEnumerable<int> IdCourses { get; set; } // lista de ids de cursos
    }
}
