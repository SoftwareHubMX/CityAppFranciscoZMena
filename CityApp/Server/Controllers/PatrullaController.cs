using CityApp.Server.Logic.AlertaLogic;
using CityApp.Server.Logic.PatrullaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaEntradaModel;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatrullaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public PatrullaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearPatrulla")]
        public IActionResult CrearPatrulla([FromBody] Peticion<Patrulla> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearPatrullaLogic crearPatrullaLogic = new CrearPatrullaLogic(CityAppContext, peticion.Data);
                response = crearPatrullaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarPatrullas")]
        public IActionResult ConsultarPatrullas([FromBody] Peticion<FiltroPatrullas> peticion)
        {
            Response<List<Patrulla>> response = new Response<List<Patrulla>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarPatrullasLogic consultarPatrullasLogic = new ConsultarPatrullasLogic(CityAppContext, peticion.Data);
                response = consultarPatrullasLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarPatrullaUsuario")]
        public IActionResult ConsultarPatrullaUsuario([FromBody] Peticion<string> peticion)
        {
            Response<Patrulla> response = new Response<Patrulla>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarPatrullaUsuarioLogic consultarPatrullaUsuarioLogic = new ConsultarPatrullaUsuarioLogic(CityAppContext, peticion.Data, peticion.Identificador);
                response = consultarPatrullaUsuarioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarPatrulla")]
        public IActionResult ConsultarPatrulla([FromBody] Peticion<int> peticion)
        {
            Response<Patrulla> response = new Response<Patrulla>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarPatrullaLogic consultarPatrullaLogic = new ConsultarPatrullaLogic(CityAppContext, peticion.Data);
                response = consultarPatrullaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarPatrulla")]
        public IActionResult ActualizarPatrulla([FromBody] Peticion<Patrulla> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarPatrullaLogic actualizarPatrullaLogic = new ActualizarPatrullaLogic(CityAppContext, peticion.Data);
                response = actualizarPatrullaLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarPatrulla")]
        public IActionResult EliminarPatrulla([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarPatrullaLogic eliminarPatrullaLogic = new EliminarPatrullaLogic(CityAppContext, peticion.Data);
                response = eliminarPatrullaLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
