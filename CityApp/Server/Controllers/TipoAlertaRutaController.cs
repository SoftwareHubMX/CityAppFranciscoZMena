using CityApp.Server.Logic.TipoAlrtaRutaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAlertaRutaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoAlertaRutaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarTiposAlertaRuta")]
        public IActionResult ConsultarTiposAlertaRuta([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoAlertaRuta>> response = new Response<List<TipoAlertaRuta>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTiposAlertaRutaLogic consultarTiposAlertaRutaLogic = new ConsultarTiposAlertaRutaLogic(CityAppContext);
                response = consultarTiposAlertaRutaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
