using CityApp.Server.Logic.ContactoSeguridadPublicaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoSeguridadPublicaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ContactoSeguridadPublicaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearContactoSeguridadPublica")]
        public IActionResult CrearContactoSeguridadPublica([FromBody] Peticion<ContactoSeguridadPublica> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearContactoSeguridadPublicaLogic crearContactoSeguridadPublicaLogic = new CrearContactoSeguridadPublicaLogic(CityAppContext, peticion.Data);
                response = crearContactoSeguridadPublicaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarContactosSeguridadPublica")]
        public IActionResult ConsultarContactosSeguridadPublica([FromBody] Peticion<object> peticion)
        {
            Response<List<ContactoSeguridadPublica>> response = new Response<List<ContactoSeguridadPublica>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarContactosSeguridadPublicaLogic consultarContactosSeguridadPublicaLogic = new ConsultarContactosSeguridadPublicaLogic(CityAppContext);
                response = consultarContactosSeguridadPublicaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarContactoSeguridadPublica")]
        public IActionResult ConsultarContactoSeguridadPublica([FromBody] Peticion<int> peticion)
        {
            Response<ContactoSeguridadPublica> response = new Response<ContactoSeguridadPublica>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarContactoSeguridadPublicaLogic consultarContactoSeguridadPublicaLogic = new ConsultarContactoSeguridadPublicaLogic(CityAppContext, peticion.Data);
                response = consultarContactoSeguridadPublicaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarContactoSeguridadPublica")]
        public IActionResult ActualizarContactoSeguridadPublica([FromBody] Peticion<ContactoSeguridadPublica> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarContactoSeguridadPublicaLogic actualizarContactoSeguridadPublicaLogic = new ActualizarContactoSeguridadPublicaLogic(CityAppContext, peticion.Data);
                response = actualizarContactoSeguridadPublicaLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarContactoSeguridadPublica")]
        public IActionResult EliminarContactoSeguridadPublica([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarContactoSeguridadPublicaLogic eliminarContactoSeguridadPublicaLogic = new EliminarContactoSeguridadPublicaLogic(CityAppContext, peticion.Data);
                response = eliminarContactoSeguridadPublicaLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
