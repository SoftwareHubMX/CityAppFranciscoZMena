using CityApp.Server.Logic.TipoTramiteLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoTramiteController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoTramiteController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarTiposTramites")]
        public IActionResult ConsultarTiposTramites([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoTramite>> response = new Response<List<TipoTramite>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTiposTramites consultarTiposTramites = new ConsultarTiposTramites(CityAppContext);
                response = consultarTiposTramites.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
