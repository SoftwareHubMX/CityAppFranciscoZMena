using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DescuentoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DescuentoPredioPeticiones
{
    public class ConsultarDescuentosPredios
    {
        private HttpClient Cliente;
        public ConsultarDescuentosPredios(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<DescuentoPredio>>> ConsultarDescuentosPrediosAsync(string token, FiltroDescuentoPredios filtroDescuentoPredios)
        {
            Response<List<DescuentoPredio>> response = new Response<List<DescuentoPredio>>();

            string url = "DescuentoPredio/ConsultarDescuentosPredios";
            Peticion<FiltroDescuentoPredios> peticion = new Peticion<FiltroDescuentoPredios>();
            peticion.Token = token;
            peticion.Data = filtroDescuentoPredios;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroDescuentoPredios>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<DescuentoPredio>>>().Result;
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
