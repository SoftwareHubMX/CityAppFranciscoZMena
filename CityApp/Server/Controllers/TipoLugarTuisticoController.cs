using CityApp.Server.Logic.TipoLugarTuristicoLogic;
using CityApp.Server.Logic.TipoPagoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoLugarTuisticoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public TipoLugarTuisticoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultaTiposLugarTuristico")]
        public IActionResult ConsultaTiposLugarTuristico([FromBody] Peticion<object> peticion)
        {
            Response<List<TipoLugarTuristico>> response = new Response<List<TipoLugarTuristico>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultaTiposLugarTuristicoLogic consultaTiposLugarTuristicoLogic = new ConsultaTiposLugarTuristicoLogic(CityAppContext);
                response = consultaTiposLugarTuristicoLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
