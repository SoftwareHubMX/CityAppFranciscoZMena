using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DescuentoPredioPeticiones
{
    public class EliminarDescuentoPredio
    {
        private HttpClient Cliente;
        public EliminarDescuentoPredio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarDescuentoPredioAsync(string token, int idDescuentoPredio)
        {
            Response<object> response = new Response<object>();

            string url = "DescuentoPredio/EliminarDescuentoPredio";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idDescuentoPredio;
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
