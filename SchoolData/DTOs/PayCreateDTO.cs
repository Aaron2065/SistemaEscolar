using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.DTOs
{
    public class PayCreateDTO : RegistryDTO
    {
        public int IdPay {  get; set; }
        [Required(ErrorMessage = "El estudiante es requerido")]
        public int IdStudent { get; set; }
        [Required(ErrorMessage = "El tipo de pago es requerido")]
        public int IdPayType { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime InscriptionDate { get; set; }

        [Required(ErrorMessage = "El Mes es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.00")]
        public decimal Amount { get; set; }
        public IEnumerable<StudentReadDTO> Students { get; set; } = new List<StudentReadDTO>();
        public IEnumerable<PayTypeReadDTO> PayTypes { get; set; } = new List<PayTypeReadDTO>();
    }
}
