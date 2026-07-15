using CityApp.Client.Services.ApiRest.NoticiaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarNoticia
{
    public class UpdataNoticia
    {
        private NoticiaPeticiones NoticiaPeticiones;

        public UpdataNoticia(HttpClient cliente)
        {
            NoticiaPeticiones = new NoticiaPeticiones(cliente);
        }

        public async Task<Response<object>> Updata(string token, Noticia noticia)
        {
            Response<object> response = await NoticiaPeticiones.editarNoticia(token, noticia);
            return response;
        }
    }
}
