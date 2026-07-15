using CityApp.Client.Services.ApiRest.AnuncioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AnunciaoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaAnuncioLogic
{
    public class SelectAnunciosLogic
    {
        private AnuncioPeticiones AnuncioPeticiones;

        public SelectAnunciosLogic(HttpClient cliente)
        {
            AnuncioPeticiones = new AnuncioPeticiones(cliente);
        }

        public async Task<Response<List<Anuncio>>> SelectAll(string token, FiltroAnuncio filtroAnuncio)
        {
            Response<List<Anuncio>> response = await AnuncioPeticiones.consultarAnuncios(token, filtroAnuncio);
            return response;
        }
    }
}
