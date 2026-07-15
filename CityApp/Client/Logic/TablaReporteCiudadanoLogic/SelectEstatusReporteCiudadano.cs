using CityApp.Client.Services.ApiRest.EstatusReporteCiudadanoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaReporteCiudadanoLogic
{
    public class SelectEstatusReporteCiudadano
    {
        private EstatusReporteCiudadanoPeticiones EstatusReporteCiudadanoPeticiones;

        public SelectEstatusReporteCiudadano(HttpClient cliente)
        {
            EstatusReporteCiudadanoPeticiones = new EstatusReporteCiudadanoPeticiones(cliente);
        }

        public async Task<Response<List<EstatusReporteCiudadano>>> SelectAll()
        {
            Response<List<EstatusReporteCiudadano>> response = await EstatusReporteCiudadanoPeticiones.consultarEstatusReporteCiudadano();
            return response;
        }
    }
}
