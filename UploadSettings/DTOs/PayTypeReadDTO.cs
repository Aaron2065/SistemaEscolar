using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class PayTypeReadDTO : RegistryDTO
    {
        public int IdPayType { get; set; }
        public string Description { get; set; }
    }
}
