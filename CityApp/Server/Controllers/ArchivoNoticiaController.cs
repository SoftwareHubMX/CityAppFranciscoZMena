using CityApp.Server.Logic.ArchivoNoticiaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoNoticiaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ArchivoNoticiaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarArchivoNoticia/{idNoticia}/{token}")]
        public async Task<IActionResult> AgregarArchivoNoticia(int idNoticia, string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarArchivoNoticiaLogic agregarArchivoNoticiaLogic = new AgregarArchivoNoticiaLogic(CityAppContext, file, idNoticia, responseValidarPeticion.Data);
                response = await agregarArchivoNoticiaLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarArchivoNoticia")]
        public IActionResult DescargarArchivoNoticia([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                DescargarArchivoNoticiaLogic descargarArchivoNoticiaLogic = new DescargarArchivoNoticiaLogic(peticion.Data, int.Parse(peticion.Identificador));
                response = descargarArchivoNoticiaLogic.Descargar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarArchivoNoticia")]
        public IActionResult EliminarArchivoNoticia([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarArchivoNoticiaLogic eliminarArchivoNoticiaLogic = new EliminarArchivoNoticiaLogic(CityAppContext, peticion.Data);
                response = eliminarArchivoNoticiaLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
