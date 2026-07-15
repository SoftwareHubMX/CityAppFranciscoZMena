using CityApp.Client.Services.ApiRest.ArchivoDirectorioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ViewDirectorioLogic
{
    public class DownloadArchivoDirectorioLogic
    {
        private ArchivoDirectorioPeticiones ArchivoDirectorioPeticiones;

        public DownloadArchivoDirectorioLogic(HttpClient cliente)
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
