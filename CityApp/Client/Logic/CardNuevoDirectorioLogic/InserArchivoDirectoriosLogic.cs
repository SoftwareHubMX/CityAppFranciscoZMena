using CityApp.Client.Services.ApiRest.ArchivoDirectorioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevoDirectorioLogic
{
    public class InserArchivoDirectoriosLogic
    {
        private ArchivoDirectorioPeticiones ArchivoDirectorioPeticiones;

        public InserArchivoDirectoriosLogic(HttpClient cliente)
        {
            ArchivoDirectorioPeticiones = new ArchivoDirectorioPeticiones(cliente);
        }

        public async Task<Response<string>> Insert(MultipartFormDataContent content, int idDirectorio, string token)
        {
            Response<string> response = await ArchivoDirectorioPeticiones.agregarArchivoDirectorio(content, idDirectorio, token);
            return response;
        }
    }
}
