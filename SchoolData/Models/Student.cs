using System.ComponentModel.DataAnnotations;

namespace SchoolData.Models
{
    public class Student : Registry
    {
        [Key]
        public int IdStudent { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public int Age { get; set; }

        public string FotoUrl { get; set; }

        public IEnumerable<StudentCourse> IdStudentCourse { get; set; }

        public IEnumerable<EmergencyContact> IdContact { get; set; }

        public IEnumerable<Pay> IdPay { get; set; }
    }
}
