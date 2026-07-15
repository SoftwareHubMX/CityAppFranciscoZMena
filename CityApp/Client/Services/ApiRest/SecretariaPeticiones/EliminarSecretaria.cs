using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.SecretariaPeticiones
{
    public class EliminarSecretaria
    {
        private HttpClient Cliente;
        public EliminarSecretaria(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarSecretariaAsync(string token, int idSecretaria)
        {
            Response<object> response = new Response<object>();

            string url = "Secretaria/EliminarSecretaria";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idSecretaria;
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
