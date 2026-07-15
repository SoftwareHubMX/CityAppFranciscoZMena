using CityApp.Client.Services.ApiRest.ArchivoDirectorioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarDirectorioLogic
{
    public class DownloadArchivoDirectorioLogic
    {
        private ArchivoDirectorioPeticiones ArchivoDirectorioPeticiones;

        public DownloadArchivoDirectorioLogic(HttpClient cliente)
        {
            ArchivoDirectorioPeticiones = new ArchivoDirectorioPeticiones(cliente);
        }

        public async Task<Response<byte[]>> Dowload(string imagen, int idDirectorio)
        {
            Response<byte[]> response = await ArchivoDirectorioPeticiones.descargarArchivoDirectorio(imagen, idDirectorio);
            return response;
        }
    }
}
