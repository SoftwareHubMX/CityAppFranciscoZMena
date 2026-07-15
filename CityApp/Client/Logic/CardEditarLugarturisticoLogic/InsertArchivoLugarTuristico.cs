using CityApp.Client.Services.ApiRest.ArchivoLugarTuristicoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarLugarturisticoLogic
{
    public class InsertArchivoLugarTuristico
    {
        private ArchivoLugarTuristicoPeticiones ArchivoLugarTuristicoPeticiones;

        public InsertArchivoLugarTuristico(HttpClient cliente)
        {
            ArchivoLugarTuristicoPeticiones = new ArchivoLugarTuristicoPeticiones(cliente);
        }

        public async Task<Response<string>> Insert(MultipartFormDataContent content, int idLugarTuristico, string token)
        {
            Response<string> response = await ArchivoLugarTuristicoPeticiones.agregarArchivoLugarTuristico(content, idLugarTuristico, token);
            return response;
        }
    }
}
