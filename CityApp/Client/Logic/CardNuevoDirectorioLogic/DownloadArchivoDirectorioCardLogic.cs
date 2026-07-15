using CityApp.Client.Services.ApiRest.ArchivoDirectorioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevoDirectorioLogic
{
    public class DownloadArchivoDirectorioCardLogic
    {
        private ArchivoDirectorioPeticiones ArchivoDirectorioPeticiones;

        public DownloadArchivoDirectorioCardLogic(HttpClient cliente)
        {
            ArchivoDirectorioPeticiones = new ArchivoDirectorioPeticiones(cliente);
        }

        public async Task<Response<byte[]>> Download(string imagen, int idDirectorio)
        {
            Response<byte[]> response = await ArchivoDirectorioPeticiones.descargarArchivoDirectorio(imagen, idDirectorio);
            return response;
        }
    }
}
