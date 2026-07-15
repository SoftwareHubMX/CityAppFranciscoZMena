using CityApp.Client.Services.ApiRest.NoticiaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaNoticiaLogic
{
    public class InsertNoticia
    {
        private NoticiaPeticiones NoticiaPeticiones;

        public InsertNoticia(HttpClient cliente)
        {
            NoticiaPeticiones = new NoticiaPeticiones(cliente);
        }

        public async Task<Response<int>> Insert(string token, Noticia noticia)
        {
            Response<int> response = await NoticiaPeticiones.crearNoticia(token, noticia);
            return response;
        }
    }
}
