using CityApp.Server.Logic.EvidenciaSolucionReporteCiudadanoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvidenciaSolucionReporteCiudadanoController : ControllerBase
    {
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public EvidenciaSolucionReporteCiudadanoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarEvidenciaSolucionReporteCiudadano/{idReporteCiudadano}/{token}")]
        public async Task<IActionResult> AgregarEvidenciaSolucionReporteCiudadano(int idReporteCiudadano, string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarEvidenciaSolucionReporteCiudadanoLogic agregarEvidenciaSolucionReporteCiudadanoLogic = new AgregarEvidenciaSolucionReporteCiudadanoLogic(CityAppContext, file, idReporteCiudadano,responseValidarPeticion.Data);
                response = await agregarEvidenciaSolucionReporteCiudadanoLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarEvidenciaSolucionReporteCiudadano")]
        public IActionResult DescargarEvidenciaReporteCiudadano([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                DescargarEvidenciaSolucionReporteCiudadanoLogic descargarEvidenciaSolucionReporteCiudadanoLogic = new DescargarEvidenciaSolucionReporteCiudadanoLogic(int.Parse(peticion.Identificador), peticion.Data);
                response = descargarEvidenciaSolucionReporteCiudadanoLogic.Descargar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarEvidenciaSolucionReporteCiudadano")]
        public IActionResult EliminarEvidenciaSolucionReporteCiudadano([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarEvidenciaSolucionReporteCiudadanoLogic evidenciaSolucionReporteCiudadanoLogic = new EliminarEvidenciaSolucionReporteCiudadanoLogic(CityAppContext, responseValidarPeticion.Data, peticion.Data);
                response = evidenciaSolucionReporteCiudadanoLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
