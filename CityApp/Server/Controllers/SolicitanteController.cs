using CityApp.Server.Logic.SolicitanteLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitanteController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public SolicitanteController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearSolicitante")]
        public IActionResult CrearSolicitante([FromBody] Peticion<Solicitante> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearSolicitanteLogic crearSolicitanteLogic = new CrearSolicitanteLogic(CityAppContext, peticion.Data);
                response = crearSolicitanteLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
