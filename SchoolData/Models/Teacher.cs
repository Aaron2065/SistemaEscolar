using SchoolData.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Teacher : Registry
    {
        [Key]
        public int IdTeacher { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name {  get; set; }

        [Required]
        [MaxLength(100)]
        public int Age { get; set; }

        /*Foreign Key*/
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public IEnumerable<Course> IdCourse { get; set; }
    }
}
