using CityApp.Server.Logic.RutaRecoleccionLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.RutaRecoleccionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutaRecoleccionController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;
        

        public RutaRecoleccionController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearRutaRecoleccion")]
        public IActionResult CrearRutaRecoleccion([FromBody] Peticion<RutaRecoleccion> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearRutaRecoleccionLogic crearRutaRecoleccionLogic = new CrearRutaRecoleccionLogic(CityAppContext, peticion.Data);
                response = crearRutaRecoleccionLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("EliminarRutaRecoleccion")]
        public IActionResult EliminarRutaRecoleccion([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarRutaRecoleccionLogic eliminarRutaRecoleccionLogic = new EliminarRutaRecoleccionLogic(CityAppContext, peticion.Data);
                response = eliminarRutaRecoleccionLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarRutaRecoleccion")]
        public IActionResult ActualizarRutaRecoleccion([FromBody] Peticion<RutaRecoleccion> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarRutaRecoleccionLogic actualizarRutaRecoleccionLogic = new ActualizarRutaRecoleccionLogic(CityAppContext, peticion.Data);
                response = actualizarRutaRecoleccionLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarRutaRecoleccion")]
        public IActionResult ConsultarRutaRecoleccion([FromBody] Peticion<int> peticion)
        {
            Response<RutaRecoleccion> response = new Response<RutaRecoleccion>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarRutaRecoleccionLogic consultarRutaRecoleccionLogic = new ConsultarRutaRecoleccionLogic(CityAppContext, peticion.Data);
                response = consultarRutaRecoleccionLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }


        [HttpPost("ConsultarFiltroRutasRecolecciones")]
        public IActionResult ConsultarFiltroRutasRecolecciones([FromBody] Peticion<FiltroRutaRecoleccion> peticion)
        {
            Response<List<RutaRecoleccion>> response = new Response<List<RutaRecoleccion>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarFiltroRutasRecoleccionesLogic consultarFiltroRutasRecoleccionesLogic = new ConsultarFiltroRutasRecoleccionesLogic(CityAppContext, peticion.Data);
                response = consultarFiltroRutasRecoleccionesLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarRutasRecoleccion")]
        public IActionResult ConsultarRutasRecoleccion([FromBody] Peticion<int> peticion)
        {
            Response<List<RutaRecoleccion>> response = new Response<List<RutaRecoleccion>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarRutasRecoleccionLogic consultarRutasRecoleccionLogic = new ConsultarRutasRecoleccionLogic(CityAppContext);
                response = consultarRutasRecoleccionLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
