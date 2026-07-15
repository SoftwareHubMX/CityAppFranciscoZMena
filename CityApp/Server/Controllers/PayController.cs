using CityApp.Server.Logic.PagoLogic;
using CityApp.Server.Logic.PayLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public PayController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("RealizarPago")]
        public IActionResult RealizarPago([FromBody] Peticion<PagoTarjeta> peticion)
        {
            Response<Pago> response = new Response<Pago>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                RealizarPagoCardLogic realizarPagoCardLogic = new RealizarPagoCardLogic(CityAppContext, peticion.Data);
                response = realizarPagoCardLogic.Realizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
