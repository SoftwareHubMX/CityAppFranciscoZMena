using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DescuentoPredioPeticiones
{
    public class CrearDescuentoPredio
    {
        private HttpClient Cliente;
        public CrearDescuentoPredio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearDescuentoPredioAsync(string token, DescuentoPredio DescuentoPredio)
        {
            Response<object> response = new Response<object>();

            string url = "DescuentoPredio/CrearDescuentoPredio";
            Peticion<DescuentoPredio> peticion = new Peticion<DescuentoPredio>();
            peticion.Token = token;
            peticion.Data = DescuentoPredio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<DescuentoPredio>>(url, peticion);
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
