using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.SecretariaPeticiones
{
    public class ActualizarSecretaria
    {
        private HttpClient Cliente;
        public ActualizarSecretaria(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarSecretariaAsync(string token, Secretaria secretaria)
        {
            Response<object> response = new Response<object>();

            string url = "Secretaria/ActualizarSecretaria";
            Peticion<Secretaria> peticion = new Peticion<Secretaria>();
            peticion.Token = token;
            peticion.Data = secretaria;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Secretaria>>(url, peticion);
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
