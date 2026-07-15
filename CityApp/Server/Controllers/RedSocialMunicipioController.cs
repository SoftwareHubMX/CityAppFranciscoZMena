using CityApp.Server.Logic.RedSocialMunicipioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedSocialMunicipioController : ControllerBase
    {
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public RedSocialMunicipioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearRedSocialMunicipio")]
        public IActionResult CrearRedSocialMunicipio([FromBody] Peticion<RedSocialMunicipio> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearRedSocialMunicipioLogic crearRedSocialMunicipioLogic = new CrearRedSocialMunicipioLogic(CityAppContext, peticion.Data);
                response = crearRedSocialMunicipioLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarRedSocialMunicipio")]
        public IActionResult EliminarRedSocialMunicipio([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarRedSocialMunicipioLogic eliminarRedSocialMunicipioLogic = new EliminarRedSocialMunicipioLogic(CityAppContext, peticion.Data);
                response = eliminarRedSocialMunicipioLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
