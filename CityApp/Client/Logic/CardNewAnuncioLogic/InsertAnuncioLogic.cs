using CityApp.Client.Services.ApiRest.AnuncioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewAnuncioLogic
{
    public class InsertAnuncioLogic
    {
        private AnuncioPeticiones AnuncioPeticiones;

        public InsertAnuncioLogic(HttpClient cliente)
        {
            AnuncioPeticiones = new AnuncioPeticiones(cliente);
        }

        public async Task<Response<int>> Insert(string token, Anuncio anuncio)
        {
            Response<int> response = await AnuncioPeticiones.crearAnuncio(token, anuncio);
            return response;
        }
    }
}
