using CityApp.Server.Logic.EstatusCuentaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatusCuentaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public EstatusCuentaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("VerificarCorreo")]
        public IActionResult VerificarCorreo([FromBody] Peticion<string> peticion)
        {
            Response<object> response = new Response<object>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                VerificarCorreoLogic verificarCorreoLogic = new VerificarCorreoLogic(CityAppContext, peticion.Data);
                response = verificarCorreoLogic.Verificar();
                CityAppContext.Dispose();
            }
            return Ok(response);
        }
    }
}
