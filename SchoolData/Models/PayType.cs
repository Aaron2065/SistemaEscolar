using System.ComponentModel.DataAnnotations;

namespace SchoolData.Models
{
    public class PayType : Registry
    {
        [Key]
        [Required]
        public int IdPayType { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeDescription { get; set; }

        public IEnumerable<Pay> IdPay { get; set; }
    }
}
