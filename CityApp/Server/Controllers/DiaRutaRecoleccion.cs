using CityApp.Server.Logic.ColoniaRutaRecoleccionLogic;
using CityApp.Server.Logic.DiaRutaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaRutaRecoleccion : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;


        public DiaRutaRecoleccion(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearDiaRuta")]
        public IActionResult CrearDiaRuta([FromBody] Peticion<DiaRuta> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearDiaRutaLogic crearDiaRutaLogic = new CrearDiaRutaLogic(CityAppContext, peticion.Data);
                response = crearDiaRutaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarDiaRuta")]
        public IActionResult ActualizarDiaRuta([FromBody] Peticion<DiaRuta> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarDiaRutaLogic actualizarDiaRutaLogic = new ActualizarDiaRutaLogic(CityAppContext, peticion.Data);
                response = actualizarDiaRutaLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarDiasRuta")]
        public IActionResult ConsultarDiasRuta([FromBody] Peticion<int> peticion)
        {
            Response<List<DiaRuta>> response = new Response<List<DiaRuta>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDiasRutaLogic consultarDiasRutaLogic = new ConsultarDiasRutaLogic(CityAppContext, peticion.Data);
                response = consultarDiasRutaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("EliminarDiaRuta")]
        public IActionResult EliminarDiaRuta([FromBody] Peticion<DiaRuta> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarDiaRutaLogic eliminarDiaRutaLogic = new EliminarDiaRutaLogic(CityAppContext, peticion.Data);
                response = eliminarDiaRutaLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
