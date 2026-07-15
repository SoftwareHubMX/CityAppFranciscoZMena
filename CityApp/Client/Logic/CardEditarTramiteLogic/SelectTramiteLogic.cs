using CityApp.Client.Services.ApiRest.TramitePeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarTramiteLogic
{
    public class SelectTramiteLogic
    {
        private TramitePeticiones TramitePeticiones;

        public SelectTramiteLogic(HttpClient cliente)
        {
            TramitePeticiones = new TramitePeticiones(cliente);
        }

        public async Task<Response<Tramite>> Select(string token, int idTramite)
        {
            Response<Tramite> response = await TramitePeticiones.consultarTramite(token, idTramite);
            return response;
        }
    }
}
