using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.Publicacion;

namespace CityApp.Client.Services.ApiRest.NoticiaPeticiones
{
    public class NoticiaPeticiones
    {
        private CrearNoticia CrearNoticia;
        private ConsultarNoticias ConsultarNoticias;
        private ConsultarNoticia ConsultarNoticia;
        private EditarNoticia EditarNoticia;
        private EliminarNoticia EliminarNoticia;
        private PublicarNoticiaFacebook PublicarNoticiaFacebook;

        public NoticiaPeticiones(HttpClient cliente)
        {
            CrearNoticia = new CrearNoticia(cliente);
            ConsultarNoticias = new ConsultarNoticias(cliente);
            ConsultarNoticia = new ConsultarNoticia(cliente);
            EditarNoticia = new EditarNoticia(cliente);
            EliminarNoticia = new EliminarNoticia(cliente);
            PublicarNoticiaFacebook = new PublicarNoticiaFacebook(cliente);
        }

        public async Task<Response<int>> crearNoticia(string toke, Noticia noticia)
        {
            Response<int> response = await CrearNoticia.CrearNoticiaAsync(toke, noticia);
            return response;
        }

        public async Task<Response<List<Noticia>>> consultarNoticias(FiltroNoticias filtroNoticias)
        {
            Response<List<Noticia>> response = await ConsultarNoticias.ConsultarNoticiasAsync(filtroNoticias);
            return response;
        }

        public async Task<Response<Noticia>> consultarNoticia(int idNoticia)
        {
            Response<Noticia> response = await ConsultarNoticia.ConsultarNoticiaAsync(idNoticia);
            return response;
        }

        public async Task<Response<object>> editarNoticia(string toke, Noticia noticia)
        {
            Response<object> response = await EditarNoticia.EditarNoticiaAsync(toke, noticia);
            return response;
        }

        public async Task<Response<object>> eliminarNoticia(string toke, int idNoticia)
        {
            Response<object> response = await EliminarNoticia.EliminarNoticiaAsync(toke, idNoticia);
            return response;
        }

        public async Task<Response<string>> publicarNoticiaFacebook(string token, string tokenFacebook, int idNoticia)
        {
            Response<string> response = await PublicarNoticiaFacebook.PublicarNoticiaFacebookAsync(token, tokenFacebook, idNoticia);
            return response;
        }
    }
}
