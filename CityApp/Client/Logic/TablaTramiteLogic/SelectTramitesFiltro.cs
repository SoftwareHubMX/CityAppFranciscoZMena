using CityApp.Client.Services.ApiRest.TramitePeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.TramiteEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaTramiteLogic
{
    public class SelectTramitesFiltro
    {
        private TramitePeticiones TramitePeticiones;
        

        public SelectTramitesFiltro(HttpClient cliente)
        {
            TramitePeticiones = new TramitePeticiones(cliente);
        }

        public async Task<Response<List<Tramite>>> SelectAll(string token, FiltroTramite filtroTramite)
        {
            Response<List<Tramite>> response = await TramitePeticiones.consultarTramitesFiltro(token, filtroTramite);
            return response;
        }
    }
}
