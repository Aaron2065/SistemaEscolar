using SchoolData.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class StudentCourse : Registry
    {
        [Key]
        public int IdStudentCourse { get; set; }
        /*Foreign Key*/
        public int IdStudent { get; set; }
        public Student Students { get; set; }

        /*Foreign Key*/
        public int IdCource { get; set; }
        public Course Courses { get; set; }
    }
}
