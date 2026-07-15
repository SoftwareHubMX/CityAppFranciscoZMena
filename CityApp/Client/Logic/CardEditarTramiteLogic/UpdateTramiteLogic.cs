using CityApp.Client.Services.ApiRest.TramitePeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarTramiteLogic
{
    public class UpdateTramiteLogic
    {
        private TramitePeticiones TramitePeticiones;

        public UpdateTramiteLogic(HttpClient cliente)
        {
            TramitePeticiones = new TramitePeticiones(cliente);
        }

        public async Task<Response<object>> Update(string token, Tramite tramite)
        {
            Response<object> response = await TramitePeticiones.actualizarTramite(token, tramite);
            return response;
        }
    }
}
