using SistemaEscolar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.DTOs
{
    public class CourseReadyDTO : RegistryDTO
    {
        public int IdCourse { get; set; }
        public int IdGroup { get; set; }
        public int IdClass { get; set; }
        public int TeacherId { get; set; }

    }
}
