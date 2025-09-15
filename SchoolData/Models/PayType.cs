using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class PayType
    {
        public int IdPayType { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeDescription { get; set; }
    }
}
