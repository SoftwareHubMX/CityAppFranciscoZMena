using CityApp.Server.Logic.Secretarialogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SecretariaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecretariaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public SecretariaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearSecretaria")]
        public IActionResult CrearSecretaria([FromBody] Peticion<Secretaria> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if(response.Status.Exito == 1)
            {
                CrearSecretariaLogic crearSecretariaLogic = new CrearSecretariaLogic(CityAppContext, peticion.Data);
                response = crearSecretariaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("EliminarSecretaria")]
        public IActionResult EliminarSecretaria([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if(response.Status.Exito == 1)
            {
                EliminarSecretariaLogic eliminarSecretariaLogic = new EliminarSecretariaLogic(CityAppContext, peticion.Data);
                response = eliminarSecretariaLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarSecretaria")]
        public IActionResult ActualizarSecretaria([FromBody] Peticion<Secretaria> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarSecretariaLogic actualizarSecretariaLogic = new ActualizarSecretariaLogic(CityAppContext, peticion.Data);
                response = actualizarSecretariaLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarSecretaria")]
        public IActionResult ConsultarSecretaria([FromBody] Peticion<int> peticion)
        {
            Response<Secretaria> response = new Response<Secretaria>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarSecretariaLogic consultarSecretariaLogic = new ConsultarSecretariaLogic(CityAppContext, peticion.Data);
                response = consultarSecretariaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarSecretarias")]
        public IActionResult ConsultarSecretarias([FromBody] Peticion<object> peticion)
        {
            Response<List<Secretaria>> response = new Response<List<Secretaria>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if(response.Status.Exito == 1)
            {
                ConsultarSecretariasLogic consultarSecretariasLogic = new ConsultarSecretariasLogic(CityAppContext);
                response = consultarSecretariasLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok (response);
        }

        [HttpPost("ConsultarSecretariasFiltro")]
        public IActionResult ConsultarSecretariasFiltro([FromBody] Peticion<FiltroSecretaria> peticion)
        {
            Response<List<Secretaria>> response = new Response<List<Secretaria>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarSecretariasFiltroLogic consultarSecretariasFiltroLogic = new ConsultarSecretariasFiltroLogic(CityAppContext, peticion.Data);
                response = consultarSecretariasFiltroLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }   

    }
}
