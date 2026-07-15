using CityApp.Client.Services.ApiRest.NoticiaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaNoticiasLogic
{
    public class DeleteNoticia
    {
        private NoticiaPeticiones NoticiaPeticiones;

        public DeleteNoticia(HttpClient cliente)
        {
            NoticiaPeticiones = new NoticiaPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idNoticia)
        {
            Response<object> response = await NoticiaPeticiones.eliminarNoticia(token, idNoticia);
            return response;
        }
    }
}
