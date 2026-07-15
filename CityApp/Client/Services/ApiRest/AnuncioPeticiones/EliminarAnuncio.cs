using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AnuncioPeticiones
{
    public class EliminarAnuncio
    {
        private HttpClient Cliente;
        public EliminarAnuncio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarAnuncioAsync(string token, int idAnuncio)
        {
            Response<object> response = new Response<object>();

            string url = "Anuncio/EliminarAnuncio";
            Peticion<object> peticion = new Peticion<object>();
            peticion.Token = token;
            peticion.Data = idAnuncio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
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
