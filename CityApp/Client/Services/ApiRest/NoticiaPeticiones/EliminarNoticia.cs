using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.NoticiaPeticiones
{
    public class EliminarNoticia
    {
        private HttpClient Cliente;
        public EliminarNoticia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarNoticiaAsync(string token, int idNoticia)
        {
            Response<object> response = new Response<object>();

            string url = "Noticia/EliminarNoticia";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idNoticia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<object>>().Result;
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
