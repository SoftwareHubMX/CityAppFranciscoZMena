using CityApp.Server.Logic.DiscapacidadLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscapacidadController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private CityAppContext CityAppContext;

        public DiscapacidadController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarDiscapacidades")]
        public IActionResult ConsultarDiscapacidades([FromBody] Peticion<object> peticion)
        {
            Response<List<Discapacidad>> response = new Response<List<Discapacidad>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDiscapacidadesLogic consultarDiscapacidadesLogic = new ConsultarDiscapacidadesLogic(CityAppContext);
                response = consultarDiscapacidadesLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
