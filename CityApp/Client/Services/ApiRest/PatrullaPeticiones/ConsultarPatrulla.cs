using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PatrullaPeticiones
{
    public class ConsultarPatrulla
    {
        private HttpClient Cliente;
        public ConsultarPatrulla(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Patrulla>> ConsultarPatrullaAsync(string token, int idPatrulla)
        {
            Response<Patrulla> response = new Response<Patrulla>();

            string url = "Patrulla/ConsultarPatrulla";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idPatrulla;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Patrulla>>().Result;
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
