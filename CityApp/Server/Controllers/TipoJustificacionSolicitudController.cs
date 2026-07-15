using CityApp.Server.Logic.TipoJustificacionSolicitudLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoJustificacionSolicitudController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoJustificacionSolicitudController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarTipoJustificacuinSolicitud")]
        public IActionResult ConsultarTipoJustificacuinSolicitud([FromBody] Peticion<int> peticion)
        {
            Response<TipoJustificacionSolicitud> response = new Response<TipoJustificacionSolicitud>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTipoJustificacuinSolicitudLogic consultarTipoJustificacuinSolicitudLogic = new ConsultarTipoJustificacuinSolicitudLogic(CityAppContext, peticion.Data);
                response = consultarTipoJustificacuinSolicitudLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarTiposJustificacionSolicitud")]
        public IActionResult ConsultarTiposJustificacionSolicitud([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoJustificacionSolicitud>> response = new Response<List<TipoJustificacionSolicitud>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTiposJustificacionSolicitudLogic consultarTiposJustificacionSolicitudLogic = new ConsultarTiposJustificacionSolicitudLogic(CityAppContext);
                response = consultarTiposJustificacionSolicitudLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
