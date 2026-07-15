using CityApp.Client.Services.ApiRest.TipoReporteCiudadanoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaReporteCiudadanoLogic
{
    public class SelectTiposReportesCiudadanos
    {
        private TipoReporteCiudadanoPeticiones TipoReporteCiudadanoPeticiones;

        public SelectTiposReportesCiudadanos(HttpClient cliente)
        {
            TipoReporteCiudadanoPeticiones = new TipoReporteCiudadanoPeticiones(cliente);
        }

        public async Task<Response<List<TipoReporteCiudadano>>> SelectAll()
        {
            Response<List<TipoReporteCiudadano>> response = await TipoReporteCiudadanoPeticiones.consultarTiposReporteCiudadano();
            return response;
        }

    }
}
