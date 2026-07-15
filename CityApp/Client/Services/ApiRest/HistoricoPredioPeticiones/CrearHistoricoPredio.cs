using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.HistoricoPredioPeticiones
{
    public class CrearHistoricoPredio
    {
        private HttpClient Cliente;
        public CrearHistoricoPredio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearHistoricoPredioAsync(string token, HistoricoPredio HistoricoPredio)
        {
            Response<int> response = new Response<int>();

            string url = "HistoricoPredio/CrearHistoricoPredio";
            Peticion<HistoricoPredio> peticion = new Peticion<HistoricoPredio>();
            peticion.Token = token;
            peticion.Data = HistoricoPredio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<HistoricoPredio>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<int>>().Result;
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
