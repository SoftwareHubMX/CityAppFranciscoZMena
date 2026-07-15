using CityApp.Client.Services.ApiRest.ArchivoNoticiaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarNoticia
{
    public class InsertArchivoNoticia
    {
        private ArchivoNoticiaPeticiones ArchivoNoticiaPeticiones;

        public InsertArchivoNoticia(HttpClient cliente)
        {
            ArchivoNoticiaPeticiones = new ArchivoNoticiaPeticiones(cliente);
        }

        public async Task<Response<string>> Insert(MultipartFormDataContent content, int idNoticia, string token)
        {
            Response<string> response = await ArchivoNoticiaPeticiones.agregarArchivoNoticia(content, idNoticia, token);
            return response;
        }
    }
}
