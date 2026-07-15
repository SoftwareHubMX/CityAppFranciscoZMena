using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CuentaPeticiones
{
    public class ConsultarCuentas
    {
        private HttpClient Cliente;
        public ConsultarCuentas(HttpClient cliente)
        {
            Cliente = cliente;
        }
        public async Task<Response<List<Cuenta>>> ConsultarCuentaAsync(string token)
        {
            Response<List<Cuenta>> response = new Response<List<Cuenta>>();

            string url = "Cuenta/ConsultarCuentas";
            Peticion<object> peticion = new Peticion<object>();
            peticion.Token = token;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Cuenta>>>().Result;
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
