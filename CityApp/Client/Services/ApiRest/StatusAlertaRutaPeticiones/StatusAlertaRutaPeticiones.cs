using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.StatusAlertaRutaPeticiones
{
    public class StatusAlertaRutaPeticiones
    {
        private ConsultarStatusAlertaRuta ConsultarStatusAlertaRuta;

        public StatusAlertaRutaPeticiones(HttpClient cliente)
        {
            ConsultarStatusAlertaRuta = new ConsultarStatusAlertaRuta(cliente);
        }

        public async Task<Response<List<StatusAlertaRuta>>> consultarStatusAlertaRuta()
        {
            Response<List<StatusAlertaRuta>> response = await ConsultarStatusAlertaRuta.ConsultarStatusAlertaRutaAsync();
            return response;
        }
    }
}
