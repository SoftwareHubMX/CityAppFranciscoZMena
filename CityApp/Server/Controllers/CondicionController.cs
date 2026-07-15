using CityApp.Server.Logic.CondicionLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public CondicionController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarCondiciones")]
        public IActionResult ConsultarCondiciones([FromBody] Peticion<object> peticion)
        {
            Response<List<Condicion>> response = new Response<List<Condicion>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarCondicionesLogic consultarCondicionesLogic = new ConsultarCondicionesLogic(CityAppContext);
                response = consultarCondicionesLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
