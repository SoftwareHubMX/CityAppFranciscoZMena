using CityApp.Server.Logic.TipoAtencionContactoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoAtencionContactoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoAtencionContactoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarTiposAtencionesContacto")]
        public IActionResult ConsultarTiposAtencionesContacto([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoAtencionContacto>> response = new Response<List<TipoAtencionContacto>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTiposAtencionesContactoLogic consultarTiposAtencionesContactoLogic = new ConsultarTiposAtencionesContactoLogic(CityAppContext);
                response = consultarTiposAtencionesContactoLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
