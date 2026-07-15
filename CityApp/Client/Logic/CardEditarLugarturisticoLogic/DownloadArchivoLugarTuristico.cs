using CityApp.Client.Services.ApiRest.ArchivoLugarTuristicoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarLugarturisticoLogic
{
    public class DownloadArchivoLugarTuristico
    {
        private ArchivoLugarTuristicoPeticiones ArchivoLugarTuristicoPeticiones;

        public DownloadArchivoLugarTuristico(HttpClient cliente)
        {
            ArchivoLugarTuristicoPeticiones = new ArchivoLugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<byte[]>> Dowload(string imagen, int idLugarTuristico)
        {
            Response<byte[]> response = await ArchivoLugarTuristicoPeticiones.descargarArchivoLugarTuristico(imagen, idLugarTuristico);
            return response;
        }
    }
}
