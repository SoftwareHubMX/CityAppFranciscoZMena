using CityApp.Client.Services.ApiRest.NoticiaPeticiones;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.Publicacion;

namespace CityApp.Client.Logic.TablaNoticiasLogic
{
    public class PublicarNoticiaFacebook
    {
        private NoticiaPeticiones NoticiaPeticiones;

        public PublicarNoticiaFacebook(HttpClient cliente)
        {
            NoticiaPeticiones = new NoticiaPeticiones(cliente);
        }

        public async Task<Response<string>> Publicar(string token, string tokenFacebook, int idNoticia)
        {
            Response<string> response = await NoticiaPeticiones.publicarNoticiaFacebook(token, tokenFacebook, idNoticia);
            return response;
        }
    }
}
