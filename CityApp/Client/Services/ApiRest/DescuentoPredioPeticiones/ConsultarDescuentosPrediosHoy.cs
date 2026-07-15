using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DescuentoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DescuentoPredioPeticiones
{
    public class ConsultarDescuentosPrediosHoy
    {
        private HttpClient Cliente;
        public ConsultarDescuentosPrediosHoy(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<DescuentoPredio>>> ConsultarDescuentosPrediosHoyAsync()
        {
            Response<List<DescuentoPredio>> response = new Response<List<DescuentoPredio>>();

            string url = "DescuentoPredio/ConsultarDescuentosPrediosHoy";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
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
