using CityApp.Server.Logic.AgendaLogic;
using CityApp.Server.Logic.AlertaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaEntradaModel;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public AlertaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearAlerta")]
        public IActionResult CrearAlerta([FromBody] Peticion<CrearAlerta> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearAlertaLogic crearAlertaLogic = new CrearAlertaLogic(CityAppContext, responseValidarPeticion.Data, peticion.Data);
                response = crearAlertaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarAlertasUsuario")]
        public IActionResult ConsultarsAlertaUsuario([FromBody] Peticion<int> peticion)
        {
            Response<List<Alerta>> response = new Response<List<Alerta>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarAlertasUsuarioLogic consultarAlertaUsuarioLogic = new ConsultarAlertasUsuarioLogic(CityAppContext, responseValidarPeticion.Data, peticion.Data);
                response = consultarAlertaUsuarioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarAlertasAdministrador")]
        public IActionResult ConsultarAlertasAdministrador([FromBody] Peticion<int> peticion)
        {
            Response<List<Alerta>> response = new Response<List<Alerta>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarAlertasAdministradorLogic consultarAlertaAdministradorLogic = new ConsultarAlertasAdministradorLogic(CityAppContext, peticion.Data);
                response = consultarAlertaAdministradorLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarAlertaIdAlerta")]
        public IActionResult ConsultarAlertaIdAlerta([FromBody] Peticion<int> peticion)
        {
            Response<Alerta> response = new Response<Alerta>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarAlertaLogic consultarAlertaAdministradorLogic = new ConsultarAlertaLogic(CityAppContext, peticion.Data);
                response = consultarAlertaAdministradorLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarEstatusAlerta")]
        public IActionResult ActualizarEstatusAlerta([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarEstatusAlertaLogic actualizarEstatusAlertaLogic = new ActualizarEstatusAlertaLogic(CityAppContext, int.Parse(peticion.Identificador), peticion.Data);
                response = actualizarEstatusAlertaLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
