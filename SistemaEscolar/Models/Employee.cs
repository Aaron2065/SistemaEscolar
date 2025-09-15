using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Employee
    {
        public int IdEmployee { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime BornDate { get; set; }
    }
}
