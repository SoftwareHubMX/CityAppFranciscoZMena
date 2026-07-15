using CityApp.Server.Logic.AgendaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AgendaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public AgendaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearAgenda")]
        public IActionResult CrearAgenda([FromBody] Peticion<Agenda> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearAgendaLogic crearAgendaLogic = new CrearAgendaLogic(CityAppContext, peticion.Data);
                response = crearAgendaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarAgendas")]
        public IActionResult ConsultarAgendas([FromBody] Peticion<FiltroAgenda> peticion)
        {
            Response<List<Agenda>> response = new Response<List<Agenda>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarAgendasLogic consultarAgendasLogic = new ConsultarAgendasLogic(CityAppContext, peticion.Data);
                response = consultarAgendasLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarAgenda")]
        public IActionResult ConsultarAgenda([FromBody] Peticion<int> peticion)
        {
            Response<Agenda> response = new Response<Agenda>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarAgendaLogic consultarAgendaLogic = new ConsultarAgendaLogic(CityAppContext, peticion.Data);
                response = consultarAgendaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EditarAgenda")]
        public IActionResult EditarAgenda([FromBody] Peticion<Agenda> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EditarAgendaLogic editarAgendaLogic = new EditarAgendaLogic(CityAppContext, peticion.Data);
                response = editarAgendaLogic.Editar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarAgenda")]
        public IActionResult EliminarAgenda([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarAgendaLogic eliminarAgendaLogic = new EliminarAgendaLogic(CityAppContext, peticion.Data);
                response = eliminarAgendaLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
