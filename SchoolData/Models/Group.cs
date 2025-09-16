using SchoolData.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Group : Registry
    {
        [Key]
        public int IdGradeGroup { get; set; }

        [Required]
        [MaxLength(7)]
        public int Grade { get; set; }

        [Required]
        [MaxLength(1)]
        public string GroupClass { get; set; }
        
        /*Foreign Key*/
        public int IdTutor { get; set; }
        public Tutor Tutor { get; set; }

        public IEnumerable<Course> IdCourse { get; set; }
    }
}
