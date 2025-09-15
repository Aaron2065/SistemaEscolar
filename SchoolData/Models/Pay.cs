using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Pay
    {
        public int IdPay { get; set; }
        public int IdStudent  { get; set; }
        public int IdPayType { get; set; }

        [Required]
        public DateTime InscriptionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
