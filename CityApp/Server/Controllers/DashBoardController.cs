using CityApp.Server.Logic.DashBoardLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DashBoardEntradaModels;
using CityApp.Shared.Models.ControllersModels.DashBoardSalidaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashBoardController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public DashBoardController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("ConsultarDataSetReportesCiudadanos")]
        public IActionResult ConsultarDataSetReportesCiudadanos([FromBody] Peticion<FechasDashBoard> peticion)
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarReportesCiudadanosDashBoardLogic consultarReportesCiudadanosDashBoardLogic = new ConsultarReportesCiudadanosDashBoardLogic(CityAppContext, peticion.Data);
                response = consultarReportesCiudadanosDashBoardLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarDataSetIngresosYear")]
        public IActionResult ConsultarDataSetIngresosYear([FromBody] Peticion<FechasDashBoard> peticion)
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarDataSetIngresosYearLogic consultarDataSetIngresosYearLogic = new ConsultarDataSetIngresosYearLogic(CityAppContext, peticion.Data);
                response = consultarDataSetIngresosYearLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarUltimosIngresos")]
        public IActionResult ConsultarUltimosIngresos([FromBody] Peticion<object> peticion)
        {
            Response<List<UltimoPago>> response = new Response<List<UltimoPago>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarUltimosIngresosLogic consultarUltimosIngresosLogic = new ConsultarUltimosIngresosLogic(CityAppContext);
                response = consultarUltimosIngresosLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarComunicacion")]
        public IActionResult ConsultarComunicacion([FromBody] Peticion<FechasDashBoard> peticion)
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarComunicacionLogic consultarComunicacionLogic = new ConsultarComunicacionLogic(CityAppContext, peticion.Data);
                response = consultarComunicacionLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarTiposLugarTuristico")]
        public IActionResult ConsultarTiposLugarTuristico([FromBody] Peticion<FechasDashBoard> peticion)
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTipoLugarTuristicoDashBoardLogic consultarTipoLugarTuristicoDashBoardLogic = new ConsultarTipoLugarTuristicoDashBoardLogic(CityAppContext, peticion.Data);
                response = consultarTipoLugarTuristicoDashBoardLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("ConsultarTotalesBolsasTrabajo")]
        public IActionResult ConsultarTotalesBolsasTrabajo([FromBody] Peticion<FiltroTotalBolsasTrabajo> peticion)
        {
            Response<List<DataSet>> response = new Response<List<DataSet>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTotalesBolsasTrabajoLogic consultarTotalesBolsasTrabajoLogic = new ConsultarTotalesBolsasTrabajoLogic(CityAppContext, peticion.Data);
                response = consultarTotalesBolsasTrabajoLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("ConsultarTiposTramite")]
        public IActionResult ConsultarTiposTramite([FromBody] Peticion<FechasDashBoard> peticion)
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarTipoTramiteDashBoardLogic consultarTipoTramiteDashBoardLogic = new ConsultarTipoTramiteDashBoardLogic(CityAppContext, peticion.Data);
                response = consultarTipoTramiteDashBoardLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
