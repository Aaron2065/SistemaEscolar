using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.DTOs
{
    public class ClassCreateDTO : RegistryDTO
    {
        public int IdClass { get; set; }
        public string ClassName { get; set; }
        public int IdCurse { get; set; }

        public IEnumerable<ClassReadyDTO> IdCurses { get; set; } = new List<ClassReadyDTO>();
    }
}
