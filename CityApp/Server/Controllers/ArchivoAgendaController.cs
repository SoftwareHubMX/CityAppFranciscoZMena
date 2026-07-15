using CityApp.Server.Logic.ArchivoAgendaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoAgendaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ArchivoAgendaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarArchivoAgenda/{idAgenda}/{token}")]
        public async Task<IActionResult> AgregarArchivoAgenda(int idAgenda, string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarArchivoAgendaLogic agregarArchivoAgendaLogic = new AgregarArchivoAgendaLogic(CityAppContext, file, idAgenda, responseValidarPeticion.Data);
                response = await agregarArchivoAgendaLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarArchivoAgenda")]
        public IActionResult DescargarArchivoAgenda([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                DescargarArchivoAgendaLogic descargarArchivoAgendaLogic = new DescargarArchivoAgendaLogic(peticion.Data, int.Parse(peticion.Identificador));
                response = descargarArchivoAgendaLogic.Descargar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarArchivoAgenda")]
        public IActionResult EliminarArchivoAgenda([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarArchivoAgendaLogic eliminarArchivoAgendaLogic = new EliminarArchivoAgendaLogic(CityAppContext, peticion.Data);
                response = eliminarArchivoAgendaLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
