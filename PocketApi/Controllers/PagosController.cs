using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocketApi.AdelantoData;
using PocketApi.Models;
using PocketApi.PagoData;
using PocketApi.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocketApi.Controllers
{
    [ApiController]
    public class PagosController : ControllerBase
    {
        private IPagoData _pagoData;
        private IAdelantoData _adelantoData;

        public PagosController(IPagoData pagoData, IAdelantoData adelantoData)
        {
            _pagoData = pagoData;
            _adelantoData = adelantoData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPagos()
        {
            try
            {
                return Ok(_pagoData.GetPagos());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetPago(int id)
        {
            try
            {
                var adelanto = _pagoData.GetPago(id);

                if (adelanto != null)
                {
                    return Ok(_pagoData.GetPago(id));
                }

                return NotFound(new { Error = $"Pago con id {id} no encontrado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddPago(Pago pago)
        {
            try
            {
                var existingAdelanto = _adelantoData.GetAdelanto(pago.Id_Adelanto);

                if (existingAdelanto != null)
                {
                    if (pago.Monto > 0)
                    {
                        var montoPagado = _pagoData.GetMontoPagado(pago.Id_Adelanto);

                        if (pago.Monto <= existingAdelanto.Monto - montoPagado)
                        {
                            _pagoData.AddPago(pago);

                            if (montoPagado + pago.Monto == existingAdelanto.Monto)
                            {
                                _adelantoData.UpdateFechaCancelacionAdelanto(pago.Id_Adelanto);
                            }

                            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + pago.Id,
                                pago);
                        }
                        else
                        {
                            return BadRequest(new { Error = $"El monto no puede superar el saldo deudo ({existingAdelanto.Monto - montoPagado})" });
                        }

                    }
                    else
                    {
                        return BadRequest(new { Error = "El monto debe ser mayor a 0" });
                    }

                }

                return NotFound(new { Error = $"No se encontro el Adelanto {pago.Id_Adelanto}" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }

    }
}
