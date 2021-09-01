using PocketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketApi.CustomModels
{
    public class AdelantoPagos
    {
        public string Id { get; set; }
        public int Legajo { get; set; }
        public decimal Monto { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? Fecha_Cancelacion { get; set; }
        public decimal SaldoDeudor { get; set; }
        public List<Pago> Pagos { get; set; }
    }
}
