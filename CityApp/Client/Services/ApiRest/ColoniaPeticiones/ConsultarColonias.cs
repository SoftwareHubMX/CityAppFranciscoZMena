using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ColoniaPeticiones
{
    public class ConsultarColonias
    {
        private HttpClient Cliente;
        public ConsultarColonias(HttpClient cliente)
        {
            Cliente = cliente;
        }
        public async Task<Response<List<Colonia>>> ConsultarColoniasAsync()
        {
            Response<List<Colonia>> response = new Response<List<Colonia>>();

            string url = "Colonia/ConsultarColonias";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Colonia>>>().Result;
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
