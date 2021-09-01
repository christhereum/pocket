using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocketApi.Models
{
    public class Empleado
    {
        [Key]
        public int Legajo { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(1, ErrorMessage = "El {0} debe ser maximo de 1 caracter")]
        [Column(TypeName = "CHAR")]
        public string Tipo_Empleado { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        public int Dni { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(50, ErrorMessage = "El {0} debe ser maximo de 50 caracteres")]
        [Column(TypeName = "VARCHAR")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(50, ErrorMessage = "El {0} debe ser maximo de 50 caracteres")]
        [Column(TypeName = "VARCHAR")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        public int Sueldo { get; set; }
    }
}
