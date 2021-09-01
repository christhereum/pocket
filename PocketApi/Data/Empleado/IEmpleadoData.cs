using PocketApi.Models;
using System.Collections.Generic;

namespace PocketApi.EmpleadoData
{
    public interface IEmpleadoData
    {
        List<Empleado> GetEmpleados();
        Empleado GetEmpleado(int legajo);

        Empleado AddEmpleado(Empleado empleado);
        Empleado EditEmpleado(Empleado empleado);
    }
}
