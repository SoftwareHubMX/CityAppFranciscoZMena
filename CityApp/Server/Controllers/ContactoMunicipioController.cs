using CityApp.Server.Logic.ContactoMunicipioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoMunicipioController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ContactoMunicipioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearContactoMunicipio")]
        public IActionResult CrearContactoMunicipio([FromBody] Peticion<ContactoMunicipio> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearContactoMunicipioLogic crearContactoMunicipioLogic = new CrearContactoMunicipioLogic(CityAppContext, peticion.Data);
                response = crearContactoMunicipioLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarContactoMunicipioApp")]
        public IActionResult ConsultarContactoMunicipioApp([FromBody] Peticion<object> peticion)
        {
            Response<ContactoMunicipio> response = new Response<ContactoMunicipio>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarContactoMunicipioAppLogic consultarContactoMunicipioAppLogic = new ConsultarContactoMunicipioAppLogic(CityAppContext);
                response = consultarContactoMunicipioAppLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarContactoMunicipio")]
        public IActionResult ConsultarContactoMunicipio([FromBody] Peticion<int> peticion)
        {
            Response<ContactoMunicipio> response = new Response<ContactoMunicipio>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarContactoMunicipioLogic consultarContactoMunicipioLogic = new ConsultarContactoMunicipioLogic(CityAppContext, peticion.Data);
                response = consultarContactoMunicipioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarContactoMunicipio")]
        public IActionResult ActualizarContactoMunicipio([FromBody] Peticion<ContactoMunicipio> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarContactoMunicipioLogic actualizarContactoMunicipioLogic = new ActualizarContactoMunicipioLogic(CityAppContext, peticion.Data);
                response = actualizarContactoMunicipioLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
