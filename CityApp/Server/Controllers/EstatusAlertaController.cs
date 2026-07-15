using CityApp.Server.Logic.EstatusAlertaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusAlertaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public EstatusAlertaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarEstatusAlerta")]
        public IActionResult ConsultarEstatusAlerta([FromBody] Peticion<object> peticion)
        {
            Response<List<EstatusAlerta>> response = new Response<List<EstatusAlerta>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarEstatusAlertaLogic consultarEstatusAlertaLogic = new ConsultarEstatusAlertaLogic(CityAppContext);
                response = consultarEstatusAlertaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
