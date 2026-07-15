using CityApp.Client.Services.ApiRest.NoticiaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditarNoticia
{
    public class SelectNoticia
    {
        private NoticiaPeticiones NoticiaPeticiones;

        public SelectNoticia(HttpClient cliente)
        {
            NoticiaPeticiones = new NoticiaPeticiones(cliente);
        }

        public async Task<Response<Noticia>> Select(int idNoticia)
        {
            Response<Noticia> response = await NoticiaPeticiones.consultarNoticia(idNoticia);
            return response;
        }
    }
}
