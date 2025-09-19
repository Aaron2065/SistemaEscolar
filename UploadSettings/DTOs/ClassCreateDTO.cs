using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class ClassCreateDTO : RegistryDTO
    {
        public int IdClass { get; set; }
        public string ClassName { get; set; }

        public IEnumerable<ClassReadDTO> IdCurses { get; set; } = new List<ClassReadDTO>();
    }
}
