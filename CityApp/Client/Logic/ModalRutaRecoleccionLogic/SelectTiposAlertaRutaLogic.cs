using CityApp.Client.Services.ApiRest.TipoAlertaRutaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalRutaRecoleccionLogic
{
    public class SelectTiposAlertaRutaLogic
    {
        private TipoAlertaRutaPeticiones TipoAlertaRutaPeticiones;

        public SelectTiposAlertaRutaLogic(HttpClient cliente)
        {
            TipoAlertaRutaPeticiones = new TipoAlertaRutaPeticiones(cliente);
        }

        public async Task<Response<List<TipoAlertaRuta>>> SelectAll()
        {
            Response<List<TipoAlertaRuta>> response = await TipoAlertaRutaPeticiones.consultarTiposAlertaRuta();
            return response;
        }
    }
}
