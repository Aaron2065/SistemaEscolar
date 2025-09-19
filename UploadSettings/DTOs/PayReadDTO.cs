using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolService.DTOs
{
    public class PayReadDTO : RegistryDTO
    {
        public int IdPay { get; set; }
        public int IdStudent { get; set; }
        public int IdPayType { get; set; }
        public string GroupPayType { get; set; }
        public DateTime InscriptionDate { get; set; }
        public decimal Amount { get; set; }

    }
}
