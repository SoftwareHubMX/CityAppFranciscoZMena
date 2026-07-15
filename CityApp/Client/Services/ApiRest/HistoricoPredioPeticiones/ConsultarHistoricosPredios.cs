using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.HistoricoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.HistoricoPredioPeticiones
{
    public class ConsultarHistoricosPredios
    {
        private HttpClient Cliente;
        public ConsultarHistoricosPredios(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<HistoricoPredio>>> ConsultarHistoricosPrediosAsync(string token,FiltroHistoricoPredio filtroHistoricoPredios)
        {
            Response<List<HistoricoPredio>> response = new Response<List<HistoricoPredio>>();

            string url = "HistoricoPredio/ConsultarHistoricosPredios";
            Peticion<FiltroHistoricoPredio> peticion = new Peticion<FiltroHistoricoPredio>();
            peticion.Token = token;
            peticion.Data = filtroHistoricoPredios;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroHistoricoPredio>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<HistoricoPredio>>>().Result;
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
