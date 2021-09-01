using PocketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketApi.Tipo_EmpleadoData
{
    public interface ITipo_EmpleadoData
    {
        List<Tipo_Empleado> GetTipos_Empleado();
        Tipo_Empleado GetTipo_Empleado(string id);

        Tipo_Empleado AddTipo_Empleado(Tipo_Empleado tipo_adelanto);
    }
}
