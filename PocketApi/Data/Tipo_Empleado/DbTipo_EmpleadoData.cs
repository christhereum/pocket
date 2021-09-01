using PocketApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketApi.Tipo_EmpleadoData
{
    public class DbTipo_EmpleadoData : ITipo_EmpleadoData
    {
        private PocketContext _pocketContext;
        public DbTipo_EmpleadoData(PocketContext pocketContext)
        {
            _pocketContext = pocketContext;
        }

        public Tipo_Empleado AddTipo_Empleado(Tipo_Empleado tipo_empleado)
        {
            _pocketContext.Tipos_Empleado.Add(tipo_empleado);
            _pocketContext.SaveChanges();

            return tipo_empleado;
        }

        public Tipo_Empleado GetTipo_Empleado(string id)
        {
            var tipo_empleado = _pocketContext.Tipos_Empleado.Find(id);

            return tipo_empleado;
        }

        public List<Tipo_Empleado> GetTipos_Empleado()
        {
            return _pocketContext.Tipos_Empleado.ToList();
        }
    }
}
