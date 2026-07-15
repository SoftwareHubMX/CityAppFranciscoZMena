using CityApp.Client.Services.ApiRest.ArchivoDirectorioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarDirectorioLogic
{
    public class DeleteArchivoDirectorioLogic
    {
        private ArchivoDirectorioPeticiones ArchivoDirectorioPeticiones;

        public DeleteArchivoDirectorioLogic(HttpClient cliente)
        {
            ArchivoDirectorioPeticiones = new ArchivoDirectorioPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idArchivoDirectorio)
        {
            Response<object> response = await ArchivoDirectorioPeticiones.eliminarArchivoDirectorio(token, idArchivoDirectorio);
            return response;
        }
    }
}
