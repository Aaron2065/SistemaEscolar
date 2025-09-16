using SchoolData.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Course : Registry
    {
        [Key]
        public int IdCourse { get; set; }

        /*Foreign Key*/
        public int IdGroup { get; set; }
        public Group Group { get; set; }

        /*Foreign Key*/
        public int IdClass { get; set; }
        public Class Class { get; set; }

        /*Foreign Key*/
        public int TeacherId { get; set; }
        public Teacher Teachers { get; set; }

        public IEnumerable<StudentCourse> IdStudentCourse { get; set; }

    }
}
