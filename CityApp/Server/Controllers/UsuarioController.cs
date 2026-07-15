using CityApp.Server.Logic.UsuarioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public UsuarioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("ConsultarUsuario")]
        public IActionResult ConsultarUsuario([FromBody] Peticion<object> peticion)
        {
            Response<Usuario> response = new Response<Usuario>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarUsuarioLogic consultarUsuarioLogic = new ConsultarUsuarioLogic(CityAppContext, responseValidarPeticion.Data);
                response = consultarUsuarioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarUsuario")]
        public IActionResult ActualizarUsuario([FromBody] Peticion<Usuario> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarUsuarioLogic actualizarUsuarioLogic = new ActualizarUsuarioLogic(CityAppContext, peticion.Data);
                response = actualizarUsuarioLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
