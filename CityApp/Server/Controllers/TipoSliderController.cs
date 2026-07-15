using CityApp.Server.Logic.TipoSliderLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSliderController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoSliderController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarTiposSliders")]
        public IActionResult ConsultarTiposSliders([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoSlider>> response = new Response<List<TipoSlider>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTiposSliders consultarTiposSliders = new ConsultarTiposSliders(CityAppContext);
                response = consultarTiposSliders.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
