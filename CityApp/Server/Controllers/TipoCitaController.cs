using CityApp.Server.Logic.TipoCitaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCitaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoCitaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultaTiposCita")]
        public IActionResult ConsultaTiposCita([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoCita>> response = new Response<List<TipoCita>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTiposCitaLogic consultarTiposCitaLogic = new ConsultarTiposCitaLogic(CityAppContext);
                response = consultarTiposCitaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
