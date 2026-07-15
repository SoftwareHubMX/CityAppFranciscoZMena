using CityApp.Client.Services.ApiRest.AnuncioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaAnuncioLogic
{
    public class DeleteAnuncioLogic
    {
        private AnuncioPeticiones AnuncioPeticiones;

        public DeleteAnuncioLogic(HttpClient cliente)
        {
            AnuncioPeticiones = new AnuncioPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idAnuncio)
        {
            Response<object> response = await AnuncioPeticiones.eliminarAnuncio(token, idAnuncio);
            return response;
        }
    }
}
