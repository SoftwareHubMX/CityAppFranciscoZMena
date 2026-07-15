using CityApp.Server.Logic.ReporteCiudadanoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteCiudadanoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ReporteCiudadanoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearReporteCiudadano")]
        public IActionResult CrearReporteCiudadano([FromBody] Peticion<CrearReporteCiudadano> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearReporteCiudadanoLogic crearReporteCiudadanoLogic = new CrearReporteCiudadanoLogic(CityAppContext, responseValidarPeticion.Data, peticion.Data);
                response = crearReporteCiudadanoLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarReportesCiudadanosUsuario")]
        public IActionResult ConsultarReportesCiudadanosUsuario([FromBody] Peticion<FiltroReportesCiudadanos> peticion)
        {
            Response<List<ReporteCiudadano>> response = new Response<List<ReporteCiudadano>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarReportesCiudadanosUsuarioLogic consultarReportesCiudadanosUsuarioLogic = new ConsultarReportesCiudadanosUsuarioLogic(CityAppContext, responseValidarPeticion.Data, peticion.Data);
                response = consultarReportesCiudadanosUsuarioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarReportesCiudadanosAdministrador")]
        public IActionResult ConsultarReportesCiudadanosAdministrador([FromBody] Peticion<FiltroReportesCiudadanos> peticion)
        {
            Response<List<ReporteCiudadano>> response = new Response<List<ReporteCiudadano>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarReportesCiudadanosAdministradorLogic consultarReportesCiudadanosAdministradorLogic = new ConsultarReportesCiudadanosAdministradorLogic(CityAppContext, peticion.Data);
                response = consultarReportesCiudadanosAdministradorLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarReporteCiudadanoCompletoAdministrador")]
        public IActionResult ConsultarReporteCiudadanoCompletoAdministrador([FromBody] Peticion<int> peticion)
        {
            Response<ReporteCiudadano> response = new Response<ReporteCiudadano>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarReporteCiudadanoCompletoAdministradorLogic consultarReporteCiudadanoCompletoAdministradorLogic = new ConsultarReporteCiudadanoCompletoAdministradorLogic(CityAppContext, peticion.Data);
                response = consultarReporteCiudadanoCompletoAdministradorLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarEstatusReporteCiudadano")]
        public IActionResult ActualizarEstatusReporteCiudadano([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarEstatusReporteCiudadanoLogic actualizarEstatusReporteCiudadanoLogic = new ActualizarEstatusReporteCiudadanoLogic(CityAppContext, int.Parse(peticion.Identificador), peticion.Data);
                response = actualizarEstatusReporteCiudadanoLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizacionObservacionesReporteCiudadano")]
        public IActionResult ActualizacionObservacionesReporteCiudadano([FromBody] Peticion<string> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizacionObservacionesReporteCiudadanoLogic actualizacionObservacionesReporteCiudadanoLogic = new ActualizacionObservacionesReporteCiudadanoLogic(CityAppContext, int.Parse(peticion.Identificador), peticion.Data);
                response = actualizacionObservacionesReporteCiudadanoLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}