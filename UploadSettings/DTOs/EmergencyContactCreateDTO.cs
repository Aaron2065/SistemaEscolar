using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class EmergencyContactCreateDTO : RegistryDTO
    {
        [Required]
        public int IdStudent { get; set; }
    }
}
