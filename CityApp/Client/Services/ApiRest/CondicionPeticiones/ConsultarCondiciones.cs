using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CondicionPeticiones
{
    public class ConsultarCondiciones
    {
        private HttpClient Cliente;
        public ConsultarCondiciones(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Condicion>>> ConsultarCondicionesAsync()
        {
            Response<List<Condicion>> response = new Response<List<Condicion>>();

            string url = "Condicion/ConsultarCondiciones";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Condicion>>>().Result;
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
