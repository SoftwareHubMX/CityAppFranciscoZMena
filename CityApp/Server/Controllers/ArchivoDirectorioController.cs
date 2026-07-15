using CityApp.Server.Logic.ArchivoDirectorioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoDirectorioController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ArchivoDirectorioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarArchivoDirectorio/{idDirectorio}/{token}")]
        public async Task<IActionResult> AgregarArchivoDirectorio(int idDirectorio, string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarArchivoDirectorioLogic agregarArchivoDirectorioLogic = new AgregarArchivoDirectorioLogic(CityAppContext, file, idDirectorio, responseValidarPeticion.Data);
                response = await agregarArchivoDirectorioLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarArchivoDirectorio")]
        public IActionResult DescargarArchivoDirectorio([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                DescargarArchivoDirectorioLogic descargarArchivoDirectorioLogic = new DescargarArchivoDirectorioLogic(peticion.Data, int.Parse(peticion.Identificador));
                response = descargarArchivoDirectorioLogic.Descargar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarArchivoDirectorio")]
        public IActionResult EliminarArchivoDirectorio([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarArchivoDirectorioLogic eliminarArchivoDirectorioLogic = new EliminarArchivoDirectorioLogic(CityAppContext, peticion.Data);
                response = eliminarArchivoDirectorioLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
