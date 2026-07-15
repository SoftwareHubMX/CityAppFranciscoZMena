using CityApp.Client.Services.ApiRest.StatusAlertaRutaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalRutaRecoleccionLogic
{
    public class SelectStatusAlertaRutaLogic
    {
        private StatusAlertaRutaPeticiones StatusAlertaRutaPeticiones;

        public SelectStatusAlertaRutaLogic(HttpClient cliente)
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
