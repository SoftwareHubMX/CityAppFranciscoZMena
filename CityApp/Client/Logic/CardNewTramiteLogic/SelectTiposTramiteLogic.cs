using CityApp.Client.Services.ApiRest.TipoTramitePeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewTramiteLogic
{
    public class SelectTiposTramiteLogic
    {
        private TipoTramitePeticiones TipoTramitePeticiones;

        public SelectTiposTramiteLogic(HttpClient cliente)
        {
            TipoTramitePeticiones = new TipoTramitePeticiones(cliente);
        }

        public async Task<Response<List<TipoTramite>>> SelectAll()
        {
            Response<List<TipoTramite>> response = await TipoTramitePeticiones.consultarTiposTramites();
            return response;
        }
    }
}
