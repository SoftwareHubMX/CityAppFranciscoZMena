using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TipoDirectorioPeticiones
{
    public class ConsultarTiposDirectorio
    {
        private HttpClient Cliente;
        public ConsultarTiposDirectorio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<TipoDirectorio>>> ConsultarTiposDirectorioAsync()
        {
            Response<List<TipoDirectorio>> response = new Response<List<TipoDirectorio>>();

            string url = "TipoDirectorio/ConsultarTiposDirectorio";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<TipoDirectorio>>>().Result;
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
