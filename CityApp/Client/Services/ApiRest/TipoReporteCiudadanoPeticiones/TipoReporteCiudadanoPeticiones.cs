using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TipoReporteCiudadanoPeticiones
{
    public class TipoReporteCiudadanoPeticiones
    {
        private ConsultarTiposReporteCiudadano ConsultarTiposReporteCiudadano;

        public TipoReporteCiudadanoPeticiones(HttpClient cliente)
        {
            ConsultarTiposReporteCiudadano = new ConsultarTiposReporteCiudadano(cliente);
        }

        public async Task<Response<List<TipoReporteCiudadano>>> consultarTiposReporteCiudadano()
        {
            Response<List<TipoReporteCiudadano>> response = await ConsultarTiposReporteCiudadano.ConsultarTiposReporteCiudadanoAsync();
            return response;
        }
    }
}
