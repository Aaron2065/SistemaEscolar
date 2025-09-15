using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Group
    {
        public int IdGradeGroup { get; set; }

        [Required]
        [MaxLength(7)]
        public int Grade { get; set; }

        [Required]
        [MaxLength(1)]
        public string GroupClass { get; set; }
        public int IdTutor { get; set; }
    }
}
