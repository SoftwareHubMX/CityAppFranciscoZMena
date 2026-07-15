using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ColoniaPeticiones
{
    public class EliminarColonia
    {
        private HttpClient Cliente;
        public EliminarColonia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarColoniaAsync(string token, int idColonia)
        {
            Response<object> response = new Response<object>();

            string url = "Colonia/EliminarColonia";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idColonia;
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
