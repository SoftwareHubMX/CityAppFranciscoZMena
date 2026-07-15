using CityApp.Server.Logic.ColoniaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoniaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ColoniaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearColonia")]
        public IActionResult CrearColonia([FromBody] Peticion<Colonia> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearColoniaLogic crearColoniaLogic = new CrearColoniaLogic(CityAppContext, peticion.Data);
                response = crearColoniaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("EliminarColonia")]
        public IActionResult EliminarColonia([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarColoniaLogic eliminarColoniaLogic = new EliminarColoniaLogic(CityAppContext, peticion.Data);
                response = eliminarColoniaLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }


        [HttpPost("ConsultarColonia")]
        public IActionResult ConsultarColonia([FromBody] Peticion<int> peticion)
        {
            Response<Colonia> response = new Response<Colonia>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarColoniaLogic consultarColoniaLogic = new ConsultarColoniaLogic(CityAppContext, peticion.Data);
                response = consultarColoniaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarColonias")]
        public IActionResult ConsultarColonias([FromBody] Peticion<object> peticion)
        {
            Response<List<Colonia>> response = new Response<List<Colonia>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarColoniasLogic consultarColoniasLogic = new ConsultarColoniasLogic(CityAppContext);
                response = consultarColoniasLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarColonia")]
        public IActionResult ActualizarColonia([FromBody] Peticion<Colonia> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarColoniaLogic actualizarColoniaLogic = new ActualizarColoniaLogic(CityAppContext, peticion.Data);
                response = actualizarColoniaLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
