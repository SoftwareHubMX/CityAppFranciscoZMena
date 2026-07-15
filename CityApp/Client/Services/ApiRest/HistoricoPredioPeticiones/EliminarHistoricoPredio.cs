using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.HistoricoPredioPeticiones
{
    public class EliminarHistoricoPredio
    {
        private HttpClient Cliente;
        public EliminarHistoricoPredio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarHistoricoPredioAsync(string token, int idHistoricoPredio)
        {
            Response<object> response = new Response<object>();

            string url = "HistoricoPredio/EliminarHistoricoPredio";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idHistoricoPredio;
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
