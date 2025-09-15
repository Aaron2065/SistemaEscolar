using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Teacher
    {
        public int IdTeacher { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name {  get; set; }

        [Required]
        [MaxLength(100)]
        public int Age { get; set; }
    }
}
