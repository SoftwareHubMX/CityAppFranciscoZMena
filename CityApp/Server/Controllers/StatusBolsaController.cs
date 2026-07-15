using CityApp.Server.Logic.StatusBolsaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusBolsaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public StatusBolsaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarStatusBolsa")]
        public IActionResult ConsultarStatusBolsa([FromBody] Peticion<object> peticion)
        {
            Response<List<StatusBolsa>> response = new Response<List<StatusBolsa>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarStatusBolsaLogic consultarStatusBolsaLogic = new ConsultarStatusBolsaLogic(CityAppContext);
                response = consultarStatusBolsaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
