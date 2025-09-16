using SchoolData.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class EmergencyContact : Registry
    {
        [Key]
        public int IdContact { get; set; }

        /*Foreign Key*/
        public int IdStudent { get; set; }
        public Student Students { get; set; }
    }
}
