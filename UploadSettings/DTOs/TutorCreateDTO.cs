using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class TutorCreateDTO : RegistryDTO
    {
        public int IdTutor {  get; set; }
        [Required(ErrorMessage = "Se requiere el empleado")]
        public int IdEmployee { get; set; }
    }
}
