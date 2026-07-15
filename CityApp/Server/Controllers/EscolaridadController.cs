using CityApp.Server.Logic.EscolaridadLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaridadController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public EscolaridadController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarEscolaridades")]
        public IActionResult ConsultarEscolaridades([FromBody] Peticion<object> peticion)
        {
            Response<List<Escolaridad>> response = new Response<List<Escolaridad>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarEscolaridadesLogic consultarEscolaridadesLogic = new ConsultarEscolaridadesLogic(CityAppContext);
                response = consultarEscolaridadesLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
