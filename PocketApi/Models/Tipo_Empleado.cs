using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PocketApi.Models
{
    public class Tipo_Empleado
    {
        [Key]
        [MaxLength(1, ErrorMessage = "El {0} debe ser maximo de 1 caracteres")]
        [Column(TypeName = "CHAR")]
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(50, ErrorMessage = "La {0} debe ser maximo de 50 caracteres")]
        [Column(TypeName = "VARCHAR")]
        public string Descripcion { get; set; }
        public int Porcentaje_Adelanto { get; set; }
    }
}
