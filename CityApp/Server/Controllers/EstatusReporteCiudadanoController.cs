using CityApp.Server.Logic.EstatusReporteCiudadanoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusReporteCiudadanoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public EstatusReporteCiudadanoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarEstatusReporteCiudadano")]
        public IActionResult ConsultarEstatusReporteCiudadano([FromBody] Peticion<object> peticion)
        {
            Response<List<EstatusReporteCiudadano>> response = new Response<List<EstatusReporteCiudadano>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarEstatusReporteCiudadanoLogic consultarEstatusReporteCiudadanoLogic = new ConsultarEstatusReporteCiudadanoLogic(CityAppContext);
                response = consultarEstatusReporteCiudadanoLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
