using CityApp.Server.Logic.BolsaTrabajoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BolsaTrabajoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public BolsaTrabajoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearBolsaTrabajo")]
        public IActionResult CrearBolsaTrabajo([FromBody] Peticion<BolsaTrabajo> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearBolsaTrabajoLogic crearBolsaTrabajoLogic = new CrearBolsaTrabajoLogic(CityAppContext, peticion.Data);
                response = crearBolsaTrabajoLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarBolsaTrabajo")]
        public IActionResult EliminarBolsaTrabajo([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarBolsaTrabajoLogic eliminarBolsaTrabajoLogic = new EliminarBolsaTrabajoLogic(CityAppContext, peticion.Data);
                response = eliminarBolsaTrabajoLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarBolsaTrabajo")]
        public IActionResult ActualizarBolsaTrabajo([FromBody] Peticion<BolsaTrabajo> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarBolsaTrabajoLogic actualizarBolsaTrabajoLogic = new ActualizarBolsaTrabajoLogic(CityAppContext, peticion.Data);
                response = actualizarBolsaTrabajoLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarBolsaTrabajo")]
        public IActionResult ConsultarBolsaTrabajo([FromBody] Peticion<int> peticion)
        {
            Response<BolsaTrabajo> response = new Response<BolsaTrabajo>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarBolsaTrabajoLogic consultarBolsaTrabajoLogic = new ConsultarBolsaTrabajoLogic(CityAppContext, peticion.Data);
                response = consultarBolsaTrabajoLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarBolsasTrabajos")]
        public IActionResult ConsultarBolsasTrabajos([FromBody] Peticion<int> peticion)
        {
            Response<List<BolsaTrabajo>> response = new Response<List<BolsaTrabajo>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarBolsasTrabajosLogic consultarBolsasTrabajosLogic = new ConsultarBolsasTrabajosLogic(CityAppContext);
                response = consultarBolsasTrabajosLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarFiltroBolsaTrabajo")]
        public IActionResult ConsultarFiltroBolsaTrabajo([FromBody] Peticion<FiltroBolsaTrabajo> peticion)
        {
            Response<List<BolsaTrabajo>> response = new Response<List<BolsaTrabajo>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarFiltroBolsaTrabajoLogic consultarFiltroBolsaTrabajoLogic = new ConsultarFiltroBolsaTrabajoLogic(CityAppContext, peticion.Data);
                response = consultarFiltroBolsaTrabajoLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
