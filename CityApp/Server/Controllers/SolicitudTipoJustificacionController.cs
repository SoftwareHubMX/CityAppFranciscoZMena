using CityApp.Server.Logic.SolicitudPodaLogic;
using CityApp.Server.Logic.SolicitudTipoJustificacionLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudTipoJustificacionController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public SolicitudTipoJustificacionController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearSolicitudTipoJustificacion")]
        public IActionResult CrearSolicitudTipoJustificacion([FromBody] Peticion<SolicitudTipoJustificacion> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearSolicitudTipoJustificacionLogic crearSolicitudTipoJustificacionLogic = new CrearSolicitudTipoJustificacionLogic(CityAppContext, peticion.Data);
                response = crearSolicitudTipoJustificacionLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        
    }
}
