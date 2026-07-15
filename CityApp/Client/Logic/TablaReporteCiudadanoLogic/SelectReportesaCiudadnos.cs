using CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaReporteCiudadanoLogic
{
    public class SelectReportesaCiudadnos
    {
        private ReporteCiudadanoPeticiones ReporteCiudadanoPeticiones;

        public SelectReportesaCiudadnos(HttpClient cliente)
        {
            ReporteCiudadanoPeticiones = new ReporteCiudadanoPeticiones(cliente);
        }

        public async Task<Response<List<ReporteCiudadano>>> SelectAll(string token, FiltroReportesCiudadanos filtroReportesCiudadanos)
        {
            Response<List<ReporteCiudadano>> response = await ReporteCiudadanoPeticiones.consultarReportesCiudadanosAdministrador(token, filtroReportesCiudadanos);
            return response;
        }
    }
}
