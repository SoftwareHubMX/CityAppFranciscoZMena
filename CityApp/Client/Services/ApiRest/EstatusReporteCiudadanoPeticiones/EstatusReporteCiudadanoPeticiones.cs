using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.EstatusReporteCiudadanoPeticiones
{
    public class EstatusReporteCiudadanoPeticiones
    {
        private ConsultarEstatusReporteCiudadano ConsultarEstatusReporteCiudadano;

        public EstatusReporteCiudadanoPeticiones(HttpClient cliente)
        {
            ConsultarEstatusReporteCiudadano = new ConsultarEstatusReporteCiudadano(cliente);
        }

        public async Task<Response<List<EstatusReporteCiudadano>>> consultarEstatusReporteCiudadano()
        {
            Response<List<EstatusReporteCiudadano>> response = await ConsultarEstatusReporteCiudadano.ConsultarEstatusReporteCiudadanoAsync();
            return response;
        }
    }
}
