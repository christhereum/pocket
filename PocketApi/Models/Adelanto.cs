using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PocketApi.Models
{
    public class Adelanto
    {
        [Key]
        [MaxLength(10, ErrorMessage = "El {0} debe ser maximo de 10 caracteres")]
        [Column(TypeName = "VARCHAR")]
        public string Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        public int Legajo { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal Monto { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? Fecha_Cancelacion { get; set; }
    }
}
