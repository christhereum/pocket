using PocketApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace PocketApi.EmpleadoData
{
    public class DbEmpleadoData : IEmpleadoData
    {
        private PocketContext _pocketContext;
        public DbEmpleadoData(PocketContext pocketContext)
        {
            _pocketContext = pocketContext;
        }
        public Empleado AddEmpleado(Empleado empleado)
        {
            int existingDni = _pocketContext.Empleados
                .Where(x => x.Dni == empleado.Dni)
                .Count();

            if (existingDni == 0)
            {
                _pocketContext.Empleados.Add(empleado);
                _pocketContext.SaveChanges();

                return empleado;
            }

            return null;
        }

        public void DeleteEmpleado(Empleado empleado)
        {
            _pocketContext.Empleados.Remove(empleado);
            _pocketContext.SaveChanges();
        }

        public Empleado EditEmpleado(Empleado empleado)
        {
            var existingEmpleado = _pocketContext.Empleados.Find(empleado.Legajo);

            if (existingEmpleado != null)
            {
                int existingDni = _pocketContext.Empleados
                .Where(x => x.Dni == empleado.Dni)
                .Count();

                if (existingDni == 0)
                {
                    existingEmpleado.Tipo_Empleado = empleado.Tipo_Empleado;
                    existingEmpleado.Nombre = empleado.Nombre;
                    existingEmpleado.Apellido = empleado.Apellido;
                    existingEmpleado.Dni = empleado.Dni;

                    _pocketContext.Empleados.Update(existingEmpleado);
                    _pocketContext.SaveChanges();
                }
                else
                {
                    return null;
                }
            }

            return empleado;
        }

        public Empleado GetEmpleado(int legajo)
        {
            var empleado = _pocketContext.Empleados.Find(legajo);

            return empleado;
        }

        public List<Empleado> GetEmpleados()
        {
            return _pocketContext.Empleados.ToList();
        }
    }
}
