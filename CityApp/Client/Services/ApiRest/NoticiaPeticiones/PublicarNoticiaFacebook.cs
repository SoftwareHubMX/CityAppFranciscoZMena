using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.Publicacion;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NoticiaPeticiones
{
    public class PublicarNoticiaFacebook
    {
        private HttpClient Cliente;
        public PublicarNoticiaFacebook(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<string>> PublicarNoticiaFacebookAsync(string token, string tokenFacebook, int idNoticia)
        {
            Response<string> response = new Response<string>();

            string url = "Noticia/PublicarNoticiaFacebook";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Identificador = tokenFacebook;
            peticion.Data = idNoticia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<string>>().Result;
            }
            else
            {
                response.Status.Mensaje = "Error: "
                    + "\n Status: " + responsePeticion.StatusCode.ToString()
                    + "\n Alerta: " + responsePeticion.ReasonPhrase;
            }

            return response;
        }
    }
}
