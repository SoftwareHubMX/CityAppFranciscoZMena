using CityApp.Server.Logic.DependenciaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DependenciaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependenciaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;
        

        public DependenciaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearDependencia")]
        public IActionResult CrearDependencia([FromBody] Peticion<Dependencia> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearDependenciaLogic crearDependenciaLogic = new CrearDependenciaLogic(CityAppContext, peticion.Data);
                response = crearDependenciaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("EliminarDependencia")]
        public IActionResult EliminarDependencia([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarDependenciaLogic eliminarDependenciaLogic = new EliminarDependenciaLogic(CityAppContext, peticion.Data);
                response = eliminarDependenciaLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarDependencia")]
        public IActionResult ActualizarDependencia([FromBody] Peticion<Dependencia> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarDependenciaLogic actualizarDependenciaLogic = new ActualizarDependenciaLogic(CityAppContext, peticion.Data);
                response = actualizarDependenciaLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarDependencia")]
        public IActionResult ConsultarDependencia([FromBody] Peticion<int> peticion)
        {
            Response<Dependencia> response = new Response<Dependencia>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDependenciaLogic consultarDependenciaLogic = new ConsultarDependenciaLogic(CityAppContext, peticion.Data);
                response = consultarDependenciaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarDependencias")]
        public IActionResult ConsultarDependencias([FromBody] Peticion<int> peticion)
        {
            Response<List<Dependencia>> response = new Response<List<Dependencia>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDependenciasLogic consultarDependenciasLogic = new ConsultarDependenciasLogic(CityAppContext, peticion.Data);
                response = consultarDependenciasLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarDependenciasFiltro")]
        public IActionResult ConsultarDependenciasFiltro([FromBody] Peticion<FiltroDependencia> peticion)
        {
            Response<List<Dependencia>> response = new Response<List<Dependencia>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDependenciasFiltroLogic consultarDependenciasFiltroLogic = new ConsultarDependenciasFiltroLogic(CityAppContext, peticion.Data);
                response = consultarDependenciasFiltroLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }


    }
}
