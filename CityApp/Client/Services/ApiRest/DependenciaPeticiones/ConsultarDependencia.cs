using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DependenciaPeticiones
{
    public class ConsultarDependencia
    {
        private HttpClient Cliente;
        public ConsultarDependencia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Dependencia>> ConsultarDependenciaAsync(string token, int idDependendia)
        {
            Response<Dependencia> response = new Response<Dependencia>();

            string url = "Dependencia/ConsultarDependencia";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idDependendia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Dependencia>>().Result;
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
