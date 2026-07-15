using CityApp.Server.Logic.AgendaLogic;
using CityApp.Server.Logic.DescuentoPredioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DescuentoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescuentoPredioController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public DescuentoPredioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearDescuentoPredio")]
        public IActionResult CrearDescuentoPredio([FromBody] Peticion<DescuentoPredio> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearDescuentoPredioLogic crearDescuentoPredioLogic = new CrearDescuentoPredioLogic(CityAppContext, peticion.Data);
                response = crearDescuentoPredioLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarDescuentosPredios")]
        public IActionResult ConsultarsDescuentosPredio([FromBody] Peticion<FiltroDescuentoPredios> peticion)
        {
            Response<List<DescuentoPredio>> response = new Response<List<DescuentoPredio>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDescuentosPrediosLogic consultarDescuentosPredioLogic = new ConsultarDescuentosPrediosLogic(CityAppContext, peticion.Data);
                response = consultarDescuentosPredioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarDescuentosPrediosHoy")]
        public IActionResult ConsultarDescuentosPrediosHoy([FromBody] Peticion<object> peticion)
        {
            Response<List<DescuentoPredio>> response = new Response<List<DescuentoPredio>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDescuentosPrediosHoyLogic consultarDescuentosPrediosHoyLogic = new ConsultarDescuentosPrediosHoyLogic(CityAppContext);
                response = consultarDescuentosPrediosHoyLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarDescuentoPredio")]
        public IActionResult EliminarDescuentoPredio([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarDescuentoPredioLogic eliminarDescuentoPredioLogic = new EliminarDescuentoPredioLogic(CityAppContext, peticion.Data);
                response = eliminarDescuentoPredioLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
