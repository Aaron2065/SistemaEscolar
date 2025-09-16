using SchoolData.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class PayType : Registry
    {
        [Key]
        public int IdPayType { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeDescription { get; set; }

        public IEnumerable<Pay> IdPay { get; set; }
    }
}
