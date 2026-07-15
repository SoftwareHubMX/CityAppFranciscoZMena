using CityApp.Client.Services.ApiRest.ArchivoAnuncioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewAnuncioLogic
{
    public class DownloadArchivoAnuncioCardLogic
    {
        private ArchivoAnuncioPeticiones ArchivoAnuncioPeticiones;

        public DownloadArchivoAnuncioCardLogic(HttpClient cliente)
        {
            ArchivoAnuncioPeticiones = new ArchivoAnuncioPeticiones(cliente);
        }

        public async Task<Response<byte[]>> Download(string imagen, int idAnuncio)
        {
            Response<byte[]> response = await ArchivoAnuncioPeticiones.descargarArchivoAnuncio(imagen, idAnuncio);
            return response;
        }
    }
}
