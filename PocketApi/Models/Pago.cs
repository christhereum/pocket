using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocketApi.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(10, ErrorMessage = "El {0} Adelanto debe ser maximo de 10 caracteres")]
        [Column(TypeName = "VARCHAR")]
        public string Id_Adelanto { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal Monto { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
