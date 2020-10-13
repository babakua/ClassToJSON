using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClassToJSON.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        [Route("datosCliente")]
        public ActionResult<String>datosCliente()
        {
            //La clase cliente debe tambien tener dentro de ella
            //un new para cada una de las clase pago y factura.
            Cliente cliente = new Cliente { 
             factura= new Factura(),
             pago = new Pago()
            };

            //---Datos de cliente
            cliente.idCodigo = 12;
            cliente.nombre = "John";
            cliente.apellido = "White";

            //---Datos de la factura
            cliente.factura.idFactura = 145;
            cliente.factura.descripcion = "Compra de mouse";
            cliente.factura.montoTotal = 1500;

            //----Datos del pago
            cliente.pago.idPago = 2325;
            cliente.pago.concepto = "Pago de Mouse";
            cliente.pago.montoPago = 1500;


            return new OkObjectResult(cliente);
        }


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
