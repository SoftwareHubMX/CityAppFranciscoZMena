using CityApp.Server.Logic.AlertaRutaLogic;
using CityApp.Server.Logic.RutaRecoleccionLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaRutaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertaRutaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public AlertaRutaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearAlertaRuta")]
        public IActionResult CrearAlertaRuta([FromBody] Peticion<AlertaRuta> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearAlertaRutaLogic crearAlertaRutaLogic = new CrearAlertaRutaLogic(CityAppContext, peticion.Data);
                response = crearAlertaRutaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarFiltroAlertaRuta")]
        public IActionResult ConsultarFiltroAlertaRuta([FromBody] Peticion<FiltroAlertaRuta> peticion)
        {
            Response<List<AlertaRuta>> response = new Response<List<AlertaRuta>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarFiltroAlertaRutaLogic consultarFiltroAlertaRutaLogic = new ConsultarFiltroAlertaRutaLogic(CityAppContext, peticion.Data);
                response = consultarFiltroAlertaRutaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarAlertaRuta")]
        public IActionResult ActualizarAlertaRuta([FromBody] Peticion<AlertaRuta> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarAlertaRutaLogic actualizarAlertaRutaLogic = new ActualizarAlertaRutaLogic(CityAppContext, peticion.Data);
                response = actualizarAlertaRutaLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarStatusAlertaRuta")]
        public IActionResult ActualizarStatusAlertaRuta([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarStatusAlertaRutaLogic actualizarStatusAlertaRutaLogic = new ActualizarStatusAlertaRutaLogic(CityAppContext, int.Parse(peticion.Identificador), peticion.Data);
                response = actualizarStatusAlertaRutaLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
