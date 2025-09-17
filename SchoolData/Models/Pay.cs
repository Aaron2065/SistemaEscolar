using SchoolData.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaEscolar.Models
{
    public class Pay : Registry
    {
        [Key]
        public int IdPay { get; set; }
        /*Foreign Key*/
        public int IdStudent { get; set; }
        public Student Students { get; set; }

        /*Foreign Key*/
        public int IdPayType { get; set; }
        public PayType PayTypes { get; set; }

        [Required]
        public DateTime InscriptionDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}
