using CityApp.Server.Logic.TipoSolicitudLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSolicitudController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoSolicitudController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarTiposSolicitud")]
        public IActionResult ConsultarTiposSolicitud([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoSolicitud>> response = new Response<List<TipoSolicitud>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTiposSolicitudLogic consultarTiposSolicitudLogic = new ConsultarTiposSolicitudLogic(CityAppContext);
                response = consultarTiposSolicitudLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
