using CityApp.Client.Services.ApiRest.ArchivoAnuncioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewAnuncioLogic
{
    public class InsertArchivoAnuncioLogic
    {
        private ArchivoAnuncioPeticiones ArchivoAnuncioPeticiones;

        public InsertArchivoAnuncioLogic(HttpClient cliente)
        {
            ArchivoAnuncioPeticiones = new ArchivoAnuncioPeticiones(cliente);
        }

        public async Task<Response<string>> Insert(MultipartFormDataContent content, int idAnuncio, string token)
        {
            Response<string> response = await ArchivoAnuncioPeticiones.agregarArchivoAnuncio(content, idAnuncio, token);
            return response;
        }
    }
}
