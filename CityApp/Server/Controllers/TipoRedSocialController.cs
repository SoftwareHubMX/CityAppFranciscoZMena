using CityApp.Server.Logic.TipoRedSocialLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoRedSocialController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoRedSocialController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarTiposRedesSociales")]
        public IActionResult ConsultarTiposRedesSociales([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoRedSocial>> response = new Response<List<TipoRedSocial>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTiposRedesSocialesLogic consultarTiposRedesSocialesLogic = new ConsultarTiposRedesSocialesLogic(CityAppContext);
                response = consultarTiposRedesSocialesLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
