using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class EmergencyContactReadDTO : RegistryDTO
    {
        public int IdContact { get; set; }
        public int IdStudent { get; set; }
        public string StudentName { get; set; }
    }
}
