using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.SecretariaPeticiones
{
    public class ConsultarSecretarias
    {
        private HttpClient Cliente;
        public ConsultarSecretarias(HttpClient cliente)
        {
            Cliente = cliente;
        }
        public async Task<Response<List<Secretaria>>> ConsultarSecretariasAsync()
        {
            Response<List<Secretaria>> response = new Response<List<Secretaria>>();

            string url = "Secretaria/ConsultarSecretarias";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Secretaria>>>().Result;
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
