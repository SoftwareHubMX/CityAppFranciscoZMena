using CityApp.Server.Logic.RolLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public RolController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        [HttpPost("ConsultarRol")]
        public IActionResult ConsultarRol([FromBody] Peticion<int> peticion)
        {
            Response<Rol> response = new Response<Rol>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarRolLogic consultarRolLogic = new ConsultarRolLogic(CityAppContext, peticion.Data);
                response = consultarRolLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarRoles")]
        public IActionResult ConsultarRoles([FromBody] Peticion<object> peticion)
        {
            Response<List<Rol>> response = new Response<List<Rol>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarRolesLogic consultarRolesLogic = new ConsultarRolesLogic(CityAppContext);
                response = consultarRolesLogic.Consultar(); 
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
