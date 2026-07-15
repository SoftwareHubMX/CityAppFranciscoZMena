using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones
{
    public class ReporteCiudadanoPeticiones
    {
        private CrearReporteCiudadanoPeticiones CrearReporteCiudadanoPeticiones;
        private ActualizarEstatusReporteCiudadano ActualizarEstatusReporteCiudadano;
        private ConsultarReportesCiudadanosUsuario ConsultarReportesCiudadanosUsuario;
        private ConsultarReportesCiudadanosAdministrador ConsultarReportesCiudadanosAdministrador;
        private ConsultarReporteCiudadanoCompletoAdministrador ConsultarReporteCiudadanoCompletoAdministrador;
        private ActualizacionObservacionesReporte ActualizacionObservacionesReporte;

        public ReporteCiudadanoPeticiones(HttpClient cliente)
        {
            CrearReporteCiudadanoPeticiones = new CrearReporteCiudadanoPeticiones(cliente);
            ActualizarEstatusReporteCiudadano = new ActualizarEstatusReporteCiudadano(cliente);
            ConsultarReportesCiudadanosUsuario = new ConsultarReportesCiudadanosUsuario(cliente);
            ConsultarReportesCiudadanosAdministrador = new ConsultarReportesCiudadanosAdministrador(cliente);
            ConsultarReporteCiudadanoCompletoAdministrador = new ConsultarReporteCiudadanoCompletoAdministrador(cliente);
            ActualizacionObservacionesReporte = new ActualizacionObservacionesReporte(cliente); 
        }

        public async Task<Response<int>> crearReporteCiudadanoPeticiones(string token, CrearReporteCiudadano crearReporteCiudadano)
        {
            Response<int> response = await CrearReporteCiudadanoPeticiones.CrearReporteCiudadanoAsync(token, crearReporteCiudadano);
            return response;
        }

        public async Task<Response<object>> actualizarEstatusReporteCiudadano(string token, int idEstatusReporteCiudadano, int idReporteCiudadano)
        {
            Response<object> response = await ActualizarEstatusReporteCiudadano.ActualizarEstatusReporteCiudadanoAsync(token, idEstatusReporteCiudadano, idReporteCiudadano);
            return response;
        }

        public async Task<Response<object>> actualizacionObservacionesReporte(string token, string observaciones, int idReporteCiudadano)
        {
            Response<object> response = await ActualizacionObservacionesReporte.ActualizacionObservacionesReporteAsync(token, observaciones, idReporteCiudadano);
            return response;
        }
        public async Task<Response<List<ReporteCiudadano>>> consultarReportesCiudadanosUsuario(string token)
        {
            Response<List<ReporteCiudadano>> response = await ConsultarReportesCiudadanosUsuario.ConsultarReportesCiudadanosUsuarioAsync(token);
            return response;
        }
        public async Task<Response<List<ReporteCiudadano>>> consultarReportesCiudadanosAdministrador(string token, FiltroReportesCiudadanos filtroReportesCiudadanos)
        {
            Response<List<ReporteCiudadano>> response = await ConsultarReportesCiudadanosAdministrador.ConsultarReportesCiudadanosAdministradorAsync(token, filtroReportesCiudadanos);
            return response;
        }
        public async Task<Response<ReporteCiudadano>> consultarReporteCiudadanoCompletoAdministrador(string token, int idReporteCiudadano)
        {
            Response<ReporteCiudadano> response = await ConsultarReporteCiudadanoCompletoAdministrador.ConsultarReporteCiudadanoCompletoAdministradorAsync(token, idReporteCiudadano);
            return response;
        }
    }
}
