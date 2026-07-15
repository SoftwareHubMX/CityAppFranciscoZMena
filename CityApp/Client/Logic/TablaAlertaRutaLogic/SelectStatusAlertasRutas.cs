using CityApp.Client.Services.ApiRest.StatusAlertaRutaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaAlertaRutaLogic
{
    public class SelectStatusAlertasRutas
    {
        private StatusAlertaRutaPeticiones StatusAlertaRutaPeticiones;

        public SelectStatusAlertasRutas(HttpClient cliente)
        {
            StatusAlertaRutaPeticiones = new StatusAlertaRutaPeticiones(cliente);
        }

        public async Task<Response<List<StatusAlertaRuta>>> SelectAll()
        {
            Response<List<StatusAlertaRuta>> response = await StatusAlertaRutaPeticiones.consultarStatusAlertaRuta();
            return response;
        }
    }
}
