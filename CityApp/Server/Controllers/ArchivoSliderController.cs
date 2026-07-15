using CityApp.Server.Logic.ArchivoSliderLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoSliderController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ArchivoSliderController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarArchivoSlider/{idSlider}/{token}")]
        public async Task<IActionResult> AgregarArchivoSlider(int idSlider, string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarArchivoSliderLogic agregarArchivoSliderLogic = new AgregarArchivoSliderLogic(CityAppContext, file, idSlider, responseValidarPeticion.Data);
                response = await agregarArchivoSliderLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarArchivoSlider")]
        public IActionResult DescargarArchivoSlider([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                DescargarArchivoSliderLogic descargarArchivoSliderLogic = new DescargarArchivoSliderLogic(peticion.Data, int.Parse(peticion.Identificador));
                response = descargarArchivoSliderLogic.Descargar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarArchivoSlider")]
        public IActionResult EliminarArchivoSlider([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarArchivoSliderLogic eliminarArchivoSliderLogic = new EliminarArchivoSliderLogic(CityAppContext, peticion.Data);
                response = eliminarArchivoSliderLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
