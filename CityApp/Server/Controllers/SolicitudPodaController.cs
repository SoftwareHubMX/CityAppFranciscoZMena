using CityApp.Server.Logic.SolicitudPodaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SolicitanteEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudPodaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;


        public SolicitudPodaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearSolicidudPoda")]
        public IActionResult CrearSolicidudPoda([FromBody] Peticion<SolicitudPoda> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearSolicidudPodaLogic crearSolicidudPodaLogic = new CrearSolicidudPodaLogic(CityAppContext, peticion.Data);
                response = crearSolicidudPodaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        //[HttpPost("EliminarRutaRecoleccion")]
        //public IActionResult EliminarRutaRecoleccion([FromBody] Peticion<int> peticion)
        //{
        //    Response<object> response = new Response<object>();
        //    Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
        //    response.Status = responseValidarPeticion.Status;
        //    if (response.Status.Exito == 1)
        //    {
        //        EliminarRutaRecoleccionLogic eliminarRutaRecoleccionLogic = new EliminarRutaRecoleccionLogic(CityAppContext, peticion.Data);
        //        response = eliminarRutaRecoleccionLogic.Eliminar();
        //    }
        //    CityAppContext.Dispose();
        //    return Ok(response);
        //}

        //[HttpPost("ActualizarRutaRecoleccion")]
        //public IActionResult ActualizarRutaRecoleccion([FromBody] Peticion<RutaRecoleccion> peticion)
        //{
        //    Response<object> response = new Response<object>();
        //    Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
        //    response.Status = responseValidarPeticion.Status;
        //    if (response.Status.Exito == 1)
        //    {
        //        ActualizarRutaRecoleccionLogic actualizarRutaRecoleccionLogic = new ActualizarRutaRecoleccionLogic(CityAppContext, peticion.Data);
        //        response = actualizarRutaRecoleccionLogic.Actualizar();
        //    }
        //    CityAppContext.Dispose();
        //    return Ok(response);
        //}

        [HttpPost("ConsultarSolicitudPoda")]
        public IActionResult ConsultarSolicitudPoda([FromBody] Peticion<int> peticion)
        {
            Response<SolicitudPoda> response = new Response<SolicitudPoda>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarSolicitudPodaLogic consultarSolicitudPodaLogic = new ConsultarSolicitudPodaLogic(CityAppContext, peticion.Data);
                response = consultarSolicitudPodaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }


        [HttpPost("ConsultarFiltroSolicitudesPoda")]
        public IActionResult ConsultarFiltroSolicitudesPoda([FromBody] Peticion<FiltroSolicitud> peticion)
        {
            Response<List<SolicitudPoda>> response = new Response<List<SolicitudPoda>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarFiltroSolicitudesPodaLogic consultarFiltroSolicitudesPodaLogic = new ConsultarFiltroSolicitudesPodaLogic(CityAppContext, peticion.Data);
                response = consultarFiltroSolicitudesPodaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarSolicitudesPoda")]
        public IActionResult ConsultarSolicitudesPoda([FromBody] Peticion<int> peticion)
        {
            Response<List<SolicitudPoda>> response = new Response<List<SolicitudPoda>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarSolicitudesPodaLogic consultarSolicitudesPodaLogic = new ConsultarSolicitudesPodaLogic(CityAppContext);
                response = consultarSolicitudesPodaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
