using CityApp.Client.Services.ApiRest.ArchivoNoticiaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarNoticia
{
    public class DownloadArchivoNoticia
    {
        private ArchivoNoticiaPeticiones ArchivoNoticiaPeticiones;

        public DownloadArchivoNoticia(HttpClient cliente)
        {
            ArchivoNoticiaPeticiones = new ArchivoNoticiaPeticiones(cliente);
        }

        public async Task<Response<byte[]>> Dowload(string imagen, int idNotocia)
        {
            Response<byte[]> response = await ArchivoNoticiaPeticiones.descargarArchivoNoticia(imagen, idNotocia);
            return response;
        }
    }
}
