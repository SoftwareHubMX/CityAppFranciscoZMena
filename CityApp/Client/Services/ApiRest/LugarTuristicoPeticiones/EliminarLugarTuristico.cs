using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.LugarTuristicoPeticiones
{
    public class EliminarLugarTuristico
    {
        private HttpClient Cliente;
        public EliminarLugarTuristico(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarLugarTuristicoAsync(string token, int idLugarTuristico)
        {
            Response<object> response = new Response<object>();

            string url = "LugarTuristico/EliminarLugarTuristico";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idLugarTuristico;
            peticion.Token = token;

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
