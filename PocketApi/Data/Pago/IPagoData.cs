using PocketApi.Models;
using System.Collections.Generic;

namespace PocketApi.PagoData
{
    public interface IPagoData
    {
        List<Pago> GetPagos();
        Pago GetPago(int id);

        Pago AddPago(Pago pago);
        decimal GetMontoPagado(string idAdelanto);
    }
}
