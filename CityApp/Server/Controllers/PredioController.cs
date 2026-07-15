using CityApp.Server.Logic.PredioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.ControllersModels.PredioSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredioController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public PredioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearPredio")]
        public IActionResult CrearPredio([FromBody] Peticion<Predio> peticion)
        {
            Response<int> response = new Response<int>();
            CrearPredioLogic crearPredioLogic = new CrearPredioLogic(CityAppContext, peticion.Data);
            response = crearPredioLogic.Crear();
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarPredioUsuario")]
        public IActionResult ConsultarPredioUsuario([FromBody] Peticion<ConsultaPredioUsuario> peticion)
        {
            Response<InformacionPagoPredio> response = new Response<InformacionPagoPredio>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarPredioUsuarioLogic consultarPredioUsuarioLogic = new ConsultarPredioUsuarioLogic(CityAppContext, peticion.Data);
                response = consultarPredioUsuarioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarPredioPago")]
        public IActionResult ConsultarPredioPago([FromBody] Peticion<int> peticion)
        {
            Response<InformacionPagoPredio> response = new Response<InformacionPagoPredio>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarPredioPagoLogic consultarPredioPagoLogic = new ConsultarPredioPagoLogic(CityAppContext, peticion.Data);
                response = consultarPredioPagoLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarPredios")]
        public IActionResult ConsultarPredios([FromBody] Peticion<FiltroPredios> peticion)
        {
            Response<List<Predio>> response = new Response<List<Predio>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarPrediosLogic ConsultarPrediosLogic = new ConsultarPrediosLogic(CityAppContext, peticion.Data);
                response = ConsultarPrediosLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarPrediosExcel")]
        public IActionResult ActualizarPrediosExcel([FromBody] Peticion<string> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if(response.Status.Exito == 1)
            {
                ActualizarPrediosExcelLogic actualizarPrediosExcelLogic = new ActualizarPrediosExcelLogic(CityAppContext, peticion.Data);
                response = actualizarPrediosExcelLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
