using CityApp.Server.Logic.TipoReporteCiudadanoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoReporteCiudadanoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoReporteCiudadanoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarTiposReporteCiudadano")]
        public IActionResult ConsultarTiposReporteCiudadano([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoReporteCiudadano>> response = new Response<List<TipoReporteCiudadano>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTiposReporteCiudadanoLogic consultarTiposReporteCiudadanoLogic = new ConsultarTiposReporteCiudadanoLogic(CityAppContext);
                response = consultarTiposReporteCiudadanoLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
