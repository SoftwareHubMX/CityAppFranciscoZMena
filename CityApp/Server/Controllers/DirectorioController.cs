using CityApp.Server.Logic.DirectorioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DirectorioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorioController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public DirectorioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearDirectorio")]
        public IActionResult CrearDirectorio([FromBody] Peticion<Directorio> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearDirectorioLogic crearDirectorioLogic = new CrearDirectorioLogic(CityAppContext, peticion.Data);
                response = crearDirectorioLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EditarDirectorio")]
        public IActionResult EditarDirectorio([FromBody] Peticion<Directorio> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EditarDirectorioLogic editarDirectorioLogic = new EditarDirectorioLogic(CityAppContext, peticion.Data);
                response = editarDirectorioLogic.Editar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarDirectoriosFiltro")]
        public IActionResult ConsultarDirectoriosFiltro([FromBody] Peticion<FiltroDirectorio> peticion)
        {
            Response<List<Directorio>> response = new Response<List<Directorio>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDirectoriosFiltroLogic consultarDirectoriosFiltroLogic = new ConsultarDirectoriosFiltroLogic(CityAppContext, peticion.Data);
                response = consultarDirectoriosFiltroLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarDirectorio")]
        public IActionResult ConsultarDirectorio([FromBody] Peticion<int> peticion)
        {
            Response<Directorio> response = new Response<Directorio>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDirectorioLogic consultarDirectorioLogic = new ConsultarDirectorioLogic(CityAppContext, peticion.Data);
                response = consultarDirectorioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarDirectorioApp")]
        public IActionResult ConsultarDirectorioApp([FromBody] Peticion<object> peticion)
        {
            Response<List<Directorio>> response = new Response<List<Directorio>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDirectorioAppLogic consultarDirectorioAppLogic = new ConsultarDirectorioAppLogic(CityAppContext);
                response = consultarDirectorioAppLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarDirectorio")]
        public IActionResult EliminarDirectorio([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarDirectorioLogic eliminarDirectorioLogic = new EliminarDirectorioLogic(CityAppContext, peticion.Data);
                response = eliminarDirectorioLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
