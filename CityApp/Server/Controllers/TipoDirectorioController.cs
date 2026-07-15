using CityApp.Server.Logic.TipoDirectorioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDirectorioController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoDirectorioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarTiposDirectorio")]
        public IActionResult ConsultarTiposDirectorio([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoDirectorio>> response = new Response<List<TipoDirectorio>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTiposDirectorioLogic consultarTiposDirectorioLogic = new ConsultarTiposDirectorioLogic(CityAppContext);
                response = consultarTiposDirectorioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
