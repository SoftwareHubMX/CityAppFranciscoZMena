using CityApp.Server.Logic.ArchivoAnuncioLogic;
using CityApp.Server.Logic.ArchivoSolicitudPodaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoSolicitudPodaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ArchivoSolicitudPodaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarArchivoSolicitudPoda/{idSolicitudPoda}/{token}")]
        public async Task<IActionResult> AgregarArchivoSolicitudPoda(int idSolicitudPoda, string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarArchivoSolicitudPodaLogic agregarArchivoSolicitudPodaLogic = new AgregarArchivoSolicitudPodaLogic(CityAppContext, file, idSolicitudPoda, responseValidarPeticion.Data);
                response = await agregarArchivoSolicitudPodaLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarArchivoSolicitudPoda")]
        public IActionResult DescargarArchivoSolicitudPoda([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                DescargarArchivoSolicitudPodaLogic descargarArchivoSolicitudPodaLogic = new DescargarArchivoSolicitudPodaLogic(peticion.Data, int.Parse(peticion.Identificador));
                response = descargarArchivoSolicitudPodaLogic.Descargar();
            }
            return Ok(response);
        }
    }
}
