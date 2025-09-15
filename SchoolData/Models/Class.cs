using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Class
    {
        public int IdClass { get; set; }
        [Required]
        [MaxLength(50)]
        public string ClassName { get; set; }
    }
}
