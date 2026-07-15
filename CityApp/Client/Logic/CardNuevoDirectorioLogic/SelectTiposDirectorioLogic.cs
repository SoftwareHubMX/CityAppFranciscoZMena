using CityApp.Client.Services.ApiRest.TipoDirectorioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevoDirectorioLogic
{
    public class SelectTiposDirectorioLogic
    {
        private TipoDirectorioPeticiones TipoDirectorioPeticiones;

        public SelectTiposDirectorioLogic(HttpClient cliente)
        {
            TipoDirectorioPeticiones = new TipoDirectorioPeticiones(cliente);
        }

        public async Task<Response<List<TipoDirectorio>>> SelectAll()
        {
            Response<List<TipoDirectorio>> response = await TipoDirectorioPeticiones.consultarTiposDirectorio();
            return response;
        }
    }
}
