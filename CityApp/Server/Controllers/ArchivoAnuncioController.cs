using CityApp.Server.Logic.ArchivoAnuncioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoAnuncioController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ArchivoAnuncioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarArchivoAnuncio/{idAnuncio}/{token}")]
        public async Task<IActionResult> AgregarArchivoAnuncio(int idAnuncio, string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarArchivoAnuncioLogic agregarArchivoAnuncioLogic = new AgregarArchivoAnuncioLogic(CityAppContext, file, idAnuncio, responseValidarPeticion.Data);
                response = await agregarArchivoAnuncioLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarArchivoAnuncio")]
        public IActionResult DescargarArchivoAnuncio([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                DescargarArchivoAnuncioLogic descargarArchivoAnuncioLogic = new DescargarArchivoAnuncioLogic(peticion.Data, int.Parse(peticion.Identificador));
                response = descargarArchivoAnuncioLogic.Descargar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarArchivoAnuncio")]
        public IActionResult EliminarArchivoAnuncio([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarArchivoAnuncioLogic eliminarArchivoAnuncioLogic = new EliminarArchivoAnuncioLogic(CityAppContext, peticion.Data);
                response = eliminarArchivoAnuncioLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
