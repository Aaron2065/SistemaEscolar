using SchoolData.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Tutor : Registry
    {
        [Key]
        public int IdTutor { get; set; }

        [Required]
        public int IdEmployee { get; set; }

        /*Foreign Key*/
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public IEnumerable<Group> Groups { get; set; }
    }
}
