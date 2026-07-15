using CityApp.Client.Services.ApiRest.ArchivoLugarTuristicoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarLugarturisticoLogic
{
    public class DeleteArchivoLugarTuristico
    {
        private ArchivoLugarTuristicoPeticiones ArchivoLugarTuristicoPeticiones;

        public DeleteArchivoLugarTuristico(HttpClient cliente)
        {
            ArchivoLugarTuristicoPeticiones = new ArchivoLugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idArchivoLugarTuristico)
        {
            Response<object> response = await ArchivoLugarTuristicoPeticiones.eliminarArchivoLugarTuristico(token, idArchivoLugarTuristico);
            return response;
        }
    }
}
