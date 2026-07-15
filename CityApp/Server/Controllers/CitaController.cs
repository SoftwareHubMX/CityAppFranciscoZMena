using CityApp.Server.Logic.CitaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public CitaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearCita")]
        public IActionResult CrearCita([FromBody] Peticion<Cita> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearCitaLogic crearCitaLogic = new CrearCitaLogic(CityAppContext, peticion.Data);
                response = crearCitaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarFiltroCitas")]
        public IActionResult ConsultarFiltroCitas([FromBody] Peticion<FiltroCitas> peticion)
        {
            Response<List<Cita>> response = new Response<List<Cita>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarFiltroCitasLogic consultarFiltroCitasLogic = new ConsultarFiltroCitasLogic(CityAppContext, peticion.Data);
                response = consultarFiltroCitasLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
