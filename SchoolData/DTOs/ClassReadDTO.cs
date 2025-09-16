using SistemaEscolar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.DTOs
{
    public class ClassReadDTO : RegistryDTO
    {
        public int IdClass { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string ClassName { get; set; }
        public int IdCurse { get; set; }

    }
}
