using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class StudentReadDTO : RegistryDTO
    {
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string FotoUrl { get; set; }
    }
}
