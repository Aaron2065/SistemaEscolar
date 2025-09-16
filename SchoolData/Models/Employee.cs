using SchoolData.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Models
{
    public class Employee : Registry
    {
        //Definimos la PK porque no es Id
        [Key]
        public int IdEmployee { get; set; }

        //Campo requerido - longitud 100
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime BornDate { get; set; }

        /// <summary>
        /// Llave primaria de la tabla Tutores, solo para navegacion
        /// </summary>
        public IEnumerable<Tutor> tutors { get; set; }

        /// <summary>
        /// Llave primaria de la tabla Docentes, solo para navegacion
        /// </summary>
        public IEnumerable<Teacher> teachers { get; set; }

    }
}
