using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class RegistryDTO
    {
        public bool Active { get; set; } = true;

        public DateTime HighSystem { get; set; } = DateTime.Now;
        public bool Deleted { get; set; } = false;
    }
}
