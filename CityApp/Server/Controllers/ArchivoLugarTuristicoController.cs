using CityApp.Server.Logic.ArchivoLugarTuristicoLogic;
using CityApp.Server.Logic.ArchivoLugarTuristicoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoLugarTuristicoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ArchivoLugarTuristicoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarArchivoLugarTuristico/{idLugarTuristico}/{token}")]
        public async Task<IActionResult> AgregarArchivoLugarTuristico(int idLugarTuristico, string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarArchivoLugarTuristicoLogic agregarArchivoLugarTuristicoLogic = new AgregarArchivoLugarTuristicoLogic(CityAppContext, file, idLugarTuristico, responseValidarPeticion.Data);
                response = await agregarArchivoLugarTuristicoLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarArchivoLugarTuristico")]
        public IActionResult DescargarArchivoLugarTuristico([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                DescargarArchivoLugarTuristicoLogic descargarArchivoLugarTuristicoLogic = new DescargarArchivoLugarTuristicoLogic(peticion.Data, int.Parse(peticion.Identificador));
                response = descargarArchivoLugarTuristicoLogic.Descargar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarArchivoLugarTuristico")]
        public IActionResult EliminarArchivoLugarTuristico([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarArchivoLugarTuristicoLogic eliminarArchivoLugarTuristicoLogic = new EliminarArchivoLugarTuristicoLogic(CityAppContext, peticion.Data);
                response = eliminarArchivoLugarTuristicoLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
