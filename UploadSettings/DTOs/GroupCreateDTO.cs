using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class GroupCreateDTO : RegistryDTO
    {
        [Required]
        public int Grade { get; set; }

        [Required]
        [MaxLength(1)]
        public string GroupClass { get; set; }

        [Required]
        public int IdTutor { get; set; }
    }
}
