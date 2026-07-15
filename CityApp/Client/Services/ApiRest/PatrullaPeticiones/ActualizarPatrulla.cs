using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PatrullaPeticiones
{
    public class ActualizarPatrulla
    {
        private HttpClient Cliente;
        public ActualizarPatrulla(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarPatrullaAsync(string token, Patrulla Patrulla)
        {
            Response<object> response = new Response<object>();

            string url = "Patrulla/ActualizarPatrulla";
            Peticion<Patrulla> peticion = new Peticion<Patrulla>();
            peticion.Token = token;
            peticion.Data = Patrulla;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Patrulla>>(url, peticion);
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
