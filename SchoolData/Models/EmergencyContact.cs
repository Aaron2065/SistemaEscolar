using System.ComponentModel.DataAnnotations;

namespace SchoolData.Models
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
