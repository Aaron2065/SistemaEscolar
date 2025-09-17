using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class StudentCourseCreateDTO : RegistryDTO
    {
        public int IdStudent { get; set; }
        [Required(ErrorMessage = "El curso para el alumno es requerido")]
        public int IdCourse { get; set; }
    }
}
