using CityApp.Client.Services.ApiRest.TramitePeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewTramiteLogic
{
    public class InsertTramiteLogic
    {
        private TramitePeticiones TramitePeticiones;

        public InsertTramiteLogic(HttpClient cliente)
        {
            TramitePeticiones = new TramitePeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, Tramite tramite)
        {
            Response<object> response = await TramitePeticiones.crearTramite(token, tramite);
            return response;
        }
    }
}
