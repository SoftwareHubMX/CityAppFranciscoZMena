using CityApp.Client.Services.ApiRest.ArchivoAnuncioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaAnuncioLogic
{
    public class DownloadArchivoAnuncioLogic
    {
        private ArchivoAnuncioPeticiones ArchivoAnuncioPeticiones;

        public DownloadArchivoAnuncioLogic(HttpClient cliente)
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
