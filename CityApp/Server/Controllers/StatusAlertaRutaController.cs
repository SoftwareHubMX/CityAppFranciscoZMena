using CityApp.Server.Logic.StatusAlertaRutaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusAlertaRutaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public StatusAlertaRutaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarStatusAlertaRuta")]
        public IActionResult ConsultarStatusAlertaRuta([FromBody] Peticion<object> peticion)
        {
            Response<List<StatusAlertaRuta>> response = new Response<List<StatusAlertaRuta>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarStatusAlertaRutaLogic consultarStatusAlertaRutaLogic = new ConsultarStatusAlertaRutaLogic(CityAppContext);
                response = consultarStatusAlertaRutaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
