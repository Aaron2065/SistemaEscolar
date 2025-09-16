using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.DTOs
{
    public class StudentCreateDTO : RegistryDTO
    {
        public int IdStudent { get; set; }
        [Required(ErrorMessage = "El nombre del estudiante es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La edad del estudiante es requerida")]
        public int Age { get; set; }

    }
}
