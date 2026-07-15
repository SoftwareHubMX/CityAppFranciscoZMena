using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.SecretariaPeticiones
{
    public class ConsultarSecretaria
    {
        private HttpClient Cliente;
        public ConsultarSecretaria(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Secretaria>> ConsultarSecretariaAsync(string token, int idSecretaria)
        {
            Response<Secretaria> response = new Response<Secretaria>();

            string url = "Secretaria/ConsultarSecretaria";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idSecretaria;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Secretaria>>().Result;
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
