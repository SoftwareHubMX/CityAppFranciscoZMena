using CityApp.Client.Services.ApiRest.ArchivoAgendaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarAgenda
{
    public class DownloadArchivoAgenda
    {
        private ArchivoAgendaPeticiones ArchivoAgendaPeticiones;

        public DownloadArchivoAgenda(HttpClient cliente)
        {
            ArchivoAgendaPeticiones = new ArchivoAgendaPeticiones(cliente);
        }

        public async Task<Response<byte[]>> Dowload(string imagen, int idAgenda)
        {
            Response<byte[]> response = await ArchivoAgendaPeticiones.descargarArchivoAgenda(imagen, idAgenda);
            return response;
        }
    }
}
