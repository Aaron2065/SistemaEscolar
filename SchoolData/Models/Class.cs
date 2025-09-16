using SchoolData.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Class : Registry
    {
        [Key]
        public int IdClass { get; set; }
        [Required]
        [MaxLength(50)]
        public string ClassName { get; set; }

        public IEnumerable<Course> IdCourse { get; set; }
    }
}
