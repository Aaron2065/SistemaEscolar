using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolData.DTOs
{
    public class PayTypeCreateDTO : RegistryDTO
    {
        public int IdPayType { get; set; }
        [Required(ErrorMessage = "La descripcion del tipo de pago es requerida")]
        public string Description { get; set; }
    }
}
