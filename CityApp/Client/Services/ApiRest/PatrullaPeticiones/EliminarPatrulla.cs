using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PatrullaPeticiones
{
    public class EliminarPatrulla
    {
        private HttpClient Cliente;
        public EliminarPatrulla(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarPatrullaAsync(string token, int idPatrulla)
        {
            Response<object> response = new Response<object>();

            string url = "Patrulla/EliminarPatrulla";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idPatrulla;
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
