using CityApp.Server.Logic.TramiteLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.TramiteEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramiteController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public TramiteController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearTramite")]
        public IActionResult CrearTramite([FromBody] Peticion<Tramite> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearTramiteLogic crearTramiteLogic = new CrearTramiteLogic(CityAppContext, peticion.Data);
                response = crearTramiteLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarTramite")]
        public IActionResult EliminarTramite([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarTramiteLogic eliminarTramiteLogic = new EliminarTramiteLogic(CityAppContext, peticion.Data);
                response = eliminarTramiteLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarTramite")]
        public IActionResult ActualizarTramite([FromBody] Peticion<Tramite> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarTramiteLogic actualizarTramiteLogic = new ActualizarTramiteLogic(CityAppContext, peticion.Data);
                response = actualizarTramiteLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarTramite")]
        public IActionResult ConsultarTramite([FromBody] Peticion<int> peticion)
        {
            Response<Tramite> response = new Response<Tramite>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTramiteLogic consultarTramiteLogic = new ConsultarTramiteLogic(CityAppContext, peticion.Data);
                response = consultarTramiteLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarTramites")]
        public IActionResult ConsultarTramites([FromBody] Peticion<int> peticion)
        {
            Response<List<Tramite>> response = new Response<List<Tramite>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTramitesLogic consultarTramitesLogic = new ConsultarTramitesLogic(CityAppContext, peticion.Data);
                response = consultarTramitesLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarTramitesFiltro")]
        public IActionResult ConsultarTramiteSFiltro([FromBody] Peticion<FiltroTramite> peticion)
        {
            Response<List<Tramite>> response = new Response<List<Tramite>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTramitesFiltroLogic consultarTramitesFiltroLogic = new ConsultarTramitesFiltroLogic(CityAppContext, peticion.Data);
                response = consultarTramitesFiltroLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
