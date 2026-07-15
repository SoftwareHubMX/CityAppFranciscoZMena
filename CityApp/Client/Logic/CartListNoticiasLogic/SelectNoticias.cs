using CityApp.Client.Services.ApiRest.NoticiaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CartListNoticiasLogic
{
    public class SelectNoticias
    {
        private NoticiaPeticiones NoticiaPeticiones;

        public SelectNoticias(HttpClient cliente)
        {
            NoticiaPeticiones = new NoticiaPeticiones(cliente);
        }

        public async Task<Response<List<Noticia>>> SelectAll(FiltroNoticias filtroNoticias)
        {
            Response<List<Noticia>> response = await NoticiaPeticiones.consultarNoticias(filtroNoticias);
            return response;
        }
    }
}
