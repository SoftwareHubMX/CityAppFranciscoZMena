using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TipoAlertaRutaPeticiones
{
    public class TipoAlertaRutaPeticiones
    {
        private ConsultarTiposAlertaRuta ConsultarTiposAlertaRuta;

        public TipoAlertaRutaPeticiones(HttpClient cliente)
        {
            ConsultarTiposAlertaRuta = new ConsultarTiposAlertaRuta(cliente);
        }

        public async Task<Response<List<TipoAlertaRuta>>> consultarTiposAlertaRuta()
        {
            Response<List<TipoAlertaRuta>> response = await ConsultarTiposAlertaRuta.ConsultarTiposAlertaRutaAsync();
            return response;
        }
    }
}
