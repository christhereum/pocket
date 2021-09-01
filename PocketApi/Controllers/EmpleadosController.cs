using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketApi.EmpleadoData;
using PocketApi.Models;
using PocketApi.Tipo_EmpleadoData;
using System;

namespace PocketApi.Controllers
{
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private IEmpleadoData _empleadoData;
        private ITipo_EmpleadoData _tipo_EmpleadoData;

        public EmpleadosController(IEmpleadoData empleadoData, ITipo_EmpleadoData tipo_Empleado)
        {
            _empleadoData = empleadoData;
            _tipo_EmpleadoData = tipo_Empleado;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmpleados()
        {
            try
            {
                return Ok(_empleadoData.GetEmpleados());
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmpleado(int id)
        {
            try
            {
                var empleado = _empleadoData.GetEmpleado(id);

                if (empleado != null)
                {
                    return Ok(_empleadoData.GetEmpleado(id));
                }

                return NotFound(new { Error = $"Empleado con id {id} no encontrado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmpleado(Empleado empleado)
        {
            try
            {
                if (_tipo_EmpleadoData.GetTipo_Empleado(empleado.Tipo_Empleado) != null)
                {
                    if (_empleadoData.AddEmpleado(empleado) != null)
                    {
                        return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + empleado.Legajo,
                        empleado);
                    }
                    else
                    {
                        return BadRequest(new { Error = "No se pudo crear el empleado" });
                    }


                }

                return NotFound(new { Error = $"No se encontro el Tipo Empleado {empleado.Tipo_Empleado}" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmpleado(int id, Empleado empleado)
        {
            try
            {
                var existingEmpelado = _empleadoData.GetEmpleado(id);

                if (existingEmpelado != null)
                {
                    var exisingTipo_Emlpeado = _tipo_EmpleadoData.GetTipo_Empleado(empleado.Tipo_Empleado);

                    if (exisingTipo_Emlpeado != null)
                    {
                        empleado.Legajo = existingEmpelado.Legajo;

                        if (empleado.Sueldo == 0)
                            empleado.Sueldo = existingEmpelado.Sueldo;

                        if (empleado.Dni == 0)
                            empleado.Dni = existingEmpelado.Dni;

                        var empleadoUpdated = _empleadoData.EditEmpleado(empleado);

                        if (empleadoUpdated != null)
                        {
                            return Ok(empleadoUpdated);
                        }
                        else
                        {
                            return NotFound(new { Error = "No se pudo actualizar el empleado" });
                        }
                    }
                    else
                    {
                        return NotFound(new { Error = $"Tipo Empleado {empleado.Tipo_Empleado} no encontrado" });
                    }
                }

                return NotFound(new { Error = $"Empleado con id {id} no encontrado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

    }
}
