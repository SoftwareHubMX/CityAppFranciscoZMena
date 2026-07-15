using CityApp.Server.Logic.CordeenadaRutaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CorddenadaRutaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public CorddenadaRutaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("ActualizarCordeenadaRuta")]
        public IActionResult ActualizarCordeenadaRuta([FromBody] Peticion<CordeenadaRuta> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarCordeenadaRutaLogic actualizarBolsaTrabajoLogic = new ActualizarCordeenadaRutaLogic(CityAppContext, peticion.Data);
                response = actualizarBolsaTrabajoLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarCordeenadaRuta")]
        public IActionResult ConsultarCordeenadaRuta([FromBody] Peticion<int> peticion)
        {
            Response<CordeenadaRuta> response = new Response<CordeenadaRuta>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarCordeenadaRutaLOgic consultarCordeenadaRutaLOgic = new ConsultarCordeenadaRutaLOgic(CityAppContext, peticion.Data);
                response = consultarCordeenadaRutaLOgic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
