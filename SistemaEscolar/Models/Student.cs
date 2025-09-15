using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Student
    {
        public int IdStudent { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public int Age { get; set; }
    }
}
