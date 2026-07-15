using CityApp.Server.Logic.ArchivoHistoricoPredioLogic;
using CityApp.Server.Logic.HistoricoPredioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.HistoricoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoPredioController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public HistoricoPredioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearHistoricoPredio")]
        public IActionResult CrearHistoricoPredio([FromBody] Peticion<HistoricoPredio> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearHistoricoPredioLogic crearHistoricoPredioLogic = new CrearHistoricoPredioLogic(CityAppContext, peticion.Data, responseValidarPeticion.Data);
                response = crearHistoricoPredioLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarHistoricosPredios")]
        public IActionResult ConsultarHistoricosPredios([FromBody] Peticion<FiltroHistoricoPredio> peticion)
        {
            Response<List<HistoricoPredio>> response = new Response<List<HistoricoPredio>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarHistoricosPrediosLogic consultarHistoricosPrediosLogic = new ConsultarHistoricosPrediosLogic(CityAppContext, peticion.Data);
                response = consultarHistoricosPrediosLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarHistoricoPredio")]
        public IActionResult EliminarHistoricoPredio([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarHistoricoPredioLogic eliminarHistoricoPredioLogic = new EliminarHistoricoPredioLogic(CityAppContext, peticion.Data);
                response = eliminarHistoricoPredioLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
