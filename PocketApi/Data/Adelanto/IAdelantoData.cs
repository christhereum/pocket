using PocketApi.CustomModels;
using PocketApi.Models;
using System.Collections.Generic;

namespace PocketApi.AdelantoData
{
    public interface IAdelantoData
    {
        List<Adelanto> GetAdelantos();
        Adelanto GetAdelanto(string id);

        Adelanto AddAdelanto(Adelanto adelanto);
        AdelantosNoCancelados GetAdelantosNoCancelados(int legajo);
        Adelanto UpdateFechaCancelacionAdelanto(string idAdelanto);
    }
}
