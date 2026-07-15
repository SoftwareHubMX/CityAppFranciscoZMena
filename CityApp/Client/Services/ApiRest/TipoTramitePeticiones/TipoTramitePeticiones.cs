using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TipoTramitePeticiones
{
    public class TipoTramitePeticiones
    {
        private ConsultarTiposTramites ConsultarTiposTramites;

        public TipoTramitePeticiones(HttpClient cliente)
        {
            ConsultarTiposTramites = new ConsultarTiposTramites(cliente);
        }

        public async Task<Response<List<TipoTramite>>> consultarTiposTramites()
        {
            Response<List<TipoTramite>> response = await ConsultarTiposTramites.ConsultarTiposTramitesAsync();
            return response;
        }
    }
}
