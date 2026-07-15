using CityApp.Server.Logic.EstatusPagoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusPagoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public EstatusPagoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarEstatusPagos")]
        public IActionResult ConsultarEstatusPagos([FromBody] Peticion<object> peticion)
        {
            Response<List<EstatusPago>> response = new Response<List<EstatusPago>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarEstatusPagosLogic consultarEstatusPagosLogic = new ConsultarEstatusPagosLogic(CityAppContext);
                response = consultarEstatusPagosLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
