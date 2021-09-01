using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketApi.AdelantoData;
using PocketApi.EmpleadoData;
using PocketApi.Models;
using PocketApi.Params;
using PocketApi.Tipo_EmpleadoData;
using System;

namespace PocketApi.Controllers
{
    [ApiController]
    public class AdelantosController : ControllerBase
    {
        private IAdelantoData _adelantoData;
        private IEmpleadoData _empleadoData;
        private ITipo_EmpleadoData _tipo_EmpleadoData;

        public AdelantosController(IAdelantoData adelantoData, IEmpleadoData empleadoData, ITipo_EmpleadoData tipo_EmpleadoData)
        {
            _adelantoData = adelantoData;
            _empleadoData = empleadoData;
            _tipo_EmpleadoData = tipo_EmpleadoData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAdelantos()
        {
            try
            {
                return Ok(_adelantoData.GetAdelantos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetAdelanto(string id)
        {
            try
            {
                var adelanto = _adelantoData.GetAdelanto(id);

                if (adelanto != null)
                {
                    return Ok(_adelantoData.GetAdelanto(id));
                }

                return NotFound(new { Error = $"Adelanto con id {id} no encontrado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddAdelanto(Adelanto adelanto)
        {
            try
            {
                var existingEmpleado = _empleadoData.GetEmpleado(adelanto.Legajo);

                if (existingEmpleado != null)
                {
                    if (_adelantoData.GetAdelantosNoCancelados(adelanto.Legajo).Adelantos.Count < 2)
                    {
                        if (adelanto.Monto > 0)
                        {
                            var tipo_Empleado = _tipo_EmpleadoData.GetTipo_Empleado(existingEmpleado.Tipo_Empleado);

                            if (tipo_Empleado != null)
                            {
                                if (((adelanto.Monto * 100) / existingEmpleado.Sueldo) <= tipo_Empleado.Porcentaje_Adelanto)
                                {
                                    _adelantoData.AddAdelanto(adelanto);

                                    return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + adelanto.Id,
                                        adelanto);
                                }
                                else
                                {
                                    return BadRequest(new { Error = $"El monto no puede superar el {tipo_Empleado.Porcentaje_Adelanto}% del sueldo del Empleado" });
                                }
                            }
                            else
                            {
                                return BadRequest(new { Error = $"No se encontro el tipo de empleado asociado" });
                            }
                        }
                        else
                        {
                            return BadRequest(new { Error = "El monto debe ser mayor a 0" });
                        }
                    }
                    else
                    {
                        return BadRequest(new { Error = "El maximo de adelantos paralelos es 2" });
                    }

                }

                return NotFound(new { Error = $"No se encontro el empleado {adelanto.Legajo}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
            
        }

        [HttpGet]
        [Route("api/adelantosnocancelados")]
        public IActionResult GetAdelantosNoCancelados(ParamLegajo paramLegajo)
        {
            try
            {
                return Ok(_adelantoData.GetAdelantosNoCancelados(paramLegajo.Legajo));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

       
    }
}
