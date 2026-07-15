using CityApp.Server.Logic.ColoniaRutaRecoleccionLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoniaRutaRecoleccionController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ColoniaRutaRecoleccionController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearColoniaRutaRecoleccion")]
        public IActionResult CrearColoniaRutaRecoleccion([FromBody] Peticion<ColoniaRutaRecoleccion> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearColoniaRutaRecoleccionLogic crearColoniaRutaRecoleccionLogic = new CrearColoniaRutaRecoleccionLogic(CityAppContext, peticion.Data);
                response = crearColoniaRutaRecoleccionLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("EliminarColoniaRutaRecoleccion")]
        public IActionResult EliminarColoniaRutaRecoleccion([FromBody] Peticion<ColoniaRutaRecoleccion> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarColoniaRutaRecoleccionLogic eliminarColoniaRutaRecoleccionLogic = new EliminarColoniaRutaRecoleccionLogic(CityAppContext, peticion.Data);
                response = eliminarColoniaRutaRecoleccionLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
