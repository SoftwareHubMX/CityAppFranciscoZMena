using CityApp.Server.Logic.TokenLoginLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenLoginController : ControllerBase
    {
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public TokenLoginController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("EliminarTokenLogin")]
        public IActionResult EliminarTokenLogin([FromBody] Peticion<string> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarTokenLoginLogic eliminarTokenLoginLogic = new EliminarTokenLoginLogic(CityAppContext, peticion.Token);
                response = eliminarTokenLoginLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
