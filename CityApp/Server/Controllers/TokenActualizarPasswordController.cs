using CityApp.Server.Logic.TokenActualizarPasswordLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenActualizarPasswordController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TokenActualizarPasswordController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("CrearTokenActualizarPassword")]
        public IActionResult CrearTokenActualizarPassword([FromBody] Peticion<string> peticion)
        {
            Response<object> response = new Response<object>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearTokenActualizarPasswordLogic crearTokenActualizarPasswordLogic = new CrearTokenActualizarPasswordLogic(CityAppContext, peticion.Data);
                response = crearTokenActualizarPasswordLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
