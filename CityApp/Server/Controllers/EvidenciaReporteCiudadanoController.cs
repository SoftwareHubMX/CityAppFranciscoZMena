using CityApp.Server.Logic.EvidenciaReporteCiudadanoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvidenciaReporteCiudadanoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public EvidenciaReporteCiudadanoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarEvidenciaReporteCiudadano/{idVercionReporteCiudadano}/{token}")]
        public async Task<IActionResult> AgregarEvidenciaReporteCiudadano(int idVercionReporteCiudadano, string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarEvidenciaReporteCiudadanoLogic agregarEvidenciaReporteCiudadanoLogic = new AgregarEvidenciaReporteCiudadanoLogic(CityAppContext, file, idVercionReporteCiudadano);
                response = await agregarEvidenciaReporteCiudadanoLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarEvidenciaReporteCiudadano")]
        public IActionResult DescargarEvidenciaReporteCiudadano([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                int idCuenta = (peticion.Identificador != null) ? int.Parse(peticion.Identificador) : responseValidarPeticion.Data;
                DescargarEvidenciaReporteCiudadanoLogic descargarEvidenciaReporteCiudadanoLogic = new DescargarEvidenciaReporteCiudadanoLogic(int.Parse(peticion.Identificador), peticion.Data);
                response = descargarEvidenciaReporteCiudadanoLogic.Descargar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarEvidenciaReporteCiudadano")]
        public IActionResult EliminarEvidenciaReporteCiudadano([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarEvidenciaReporteCiudadanoLogic eliminarEvidenciaReporteCiudadanoLogic = new EliminarEvidenciaReporteCiudadanoLogic(CityAppContext, peticion.Data);
                response = eliminarEvidenciaReporteCiudadanoLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
