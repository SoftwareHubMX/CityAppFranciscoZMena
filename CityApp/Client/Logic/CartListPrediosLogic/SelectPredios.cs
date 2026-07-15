using CityApp.Client.Services.ApiRest.PredioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CartListPrediosLogic
{
    public class SelectPredios
    {
        private PredioPeticiones PredioPeticiones;

        public SelectPredios(HttpClient cliente)
        {
            PredioPeticiones = new PredioPeticiones(cliente);
        }

        public async Task<Response<List<Predio>>> SelectAll(string token, FiltroPredios filtroPredios)
        {
            Response<List<Predio>> response = await PredioPeticiones.consultarPredios(token, filtroPredios);
            return response;
        }
    }
}
