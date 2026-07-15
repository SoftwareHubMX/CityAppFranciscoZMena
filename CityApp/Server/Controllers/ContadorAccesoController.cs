using CityApp.Server.Logic.ContadorAccesoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContadorAccesoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public ContadorAccesoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ResetearContador")]
        public IActionResult ResetearContador([FromBody] Peticion<string> peticion)
        {
            Response<object> response = new Response<object>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ResetearContadorLogic resetearContadorLogic = new ResetearContadorLogic(CityAppContext, peticion.Data); 
                response = resetearContadorLogic.Resetear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
