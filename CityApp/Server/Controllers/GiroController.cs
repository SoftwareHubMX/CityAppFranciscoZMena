using CityApp.Server.Logic.GiroLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiroController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public GiroController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarGiros")]
        public IActionResult ConsultarGiros([FromBody] Peticion<object> peticion)
        {
            Response<List<Giro>> response = new Response<List<Giro>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarGirosLogic consultarGirosLogic = new ConsultarGirosLogic(CityAppContext);
                response = consultarGirosLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
