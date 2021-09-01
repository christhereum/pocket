using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketApi.Models;
using PocketApi.Tipo_EmpleadoData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketApi.Controllers
{
    [ApiController]
    public class Tipos_EmpleadoController : ControllerBase
    {
        private ITipo_EmpleadoData _tipo_EmpleadoData;

        public Tipos_EmpleadoController(ITipo_EmpleadoData tipo_empleadoData)
        {
            _tipo_EmpleadoData = tipo_empleadoData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAdelantos()
        {
            try
            {
                return Ok(_tipo_EmpleadoData.GetTipos_Empleado());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetTipo_Empleado(string id)
        {
            try
            {
                var tipo_Empleado = _tipo_EmpleadoData.GetTipo_Empleado(id);

                if (tipo_Empleado != null)
                {
                    return Ok(_tipo_EmpleadoData.GetTipo_Empleado(id));
                }

                return NotFound(new { Error = $"Tipo Empleado con id {id} no encontrado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddTipo_Empleado(Tipo_Empleado tipo_Empleado)
        {
            try
            {
                var existingTipo_Empleado = _tipo_EmpleadoData.GetTipo_Empleado(tipo_Empleado.Id);

                if (existingTipo_Empleado == null)
                {
                    _tipo_EmpleadoData.AddTipo_Empleado(tipo_Empleado);

                    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + tipo_Empleado.Id,
                        tipo_Empleado);
                }

                return NotFound(new { Error = $"Ya existe el Tipo Empleado {tipo_Empleado.Id}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }

        }

    }
}
