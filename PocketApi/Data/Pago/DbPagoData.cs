using PocketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketApi.PagoData
{
    public class DbPagoData : IPagoData
    {
        private PocketContext _pocketContext;
        public DbPagoData(PocketContext pocketContext)
        {
            _pocketContext = pocketContext;
        }

        public Pago AddPago(Pago pago)
        {
            pago.Fecha = DateTime.Now;
            _pocketContext.Pagos.Add(pago);
            _pocketContext.SaveChanges();

            return pago;
        }

        public Pago GetPago(int id)
        {
            var pago = _pocketContext.Pagos.Find(id);

            return pago;
        }

        public List<Pago> GetPagos()
        {
            return _pocketContext.Pagos.ToList();
        }

        public decimal GetMontoPagado(string idAdelanto)
        {
            var monto = _pocketContext.Pagos
                            .Where(x => x.Id_Adelanto == idAdelanto)
                            .Select(x => new { Monto = x.Monto })
                            .Sum(x => x.Monto);

            return monto;
        }
    }
}
