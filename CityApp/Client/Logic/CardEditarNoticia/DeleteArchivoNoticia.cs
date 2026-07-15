using CityApp.Client.Services.ApiRest.ArchivoNoticiaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarNoticia
{
    public class DeleteArchivoNoticia
    {
        private ArchivoNoticiaPeticiones ArchivoNoticiaPeticiones;

        public DeleteArchivoNoticia(HttpClient cliente)
        {
            ArchivoNoticiaPeticiones = new ArchivoNoticiaPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idArchivoNoticia)
        {
            Response<object> response = await ArchivoNoticiaPeticiones.eliminarArchivoNoticia(token, idArchivoNoticia);
            return response;
        }
    }
}
