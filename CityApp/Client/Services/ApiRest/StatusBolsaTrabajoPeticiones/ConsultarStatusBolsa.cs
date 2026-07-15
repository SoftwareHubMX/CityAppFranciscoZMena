using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.StatusBolsaTrabajoPeticiones
{
    public class ConsultarStatusBolsa
    {
        private HttpClient Cliente;
        public ConsultarStatusBolsa(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<StatusBolsa>>> ConsultarStatusBolsaAsync()
        {
            Response<List<StatusBolsa>> response = new Response<List<StatusBolsa>>();

            string url = "StatusBolsa/ConsultarStatusBolsa";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<StatusBolsa>>>().Result;
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
