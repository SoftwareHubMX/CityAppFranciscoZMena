using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.GiroPeticiones
{
    public class ConsultarGiros
    {
        private HttpClient Cliente;
        public ConsultarGiros(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Giro>>> ConsultarGirosAsync()
        {
            Response<List<Giro>> response = new Response<List<Giro>>();

            string url = "Giro/ConsultarGiros";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Giro>>>().Result;
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
