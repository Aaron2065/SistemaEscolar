using System.ComponentModel.DataAnnotations;

namespace SchoolData.Models
{
    public class Teacher : Registry
    {
        [Key]
        public int IdTeacher { get; set; }

        /*Foreign Key*/
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
