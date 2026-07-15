using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DependenciaPeticiones
{
    public class ConsultarDependencias
    {
        private HttpClient Cliente;
        public ConsultarDependencias(HttpClient cliente)
        {
            Cliente = cliente;
        }
        public async Task<Response<List<Dependencia>>> ConsultarDependenciasAsync( int idSecretaria)
        {
            Response<List<Dependencia>> response = new Response<List<Dependencia>>();

            string url = "Dependencia/ConsultarDependencias";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idSecretaria;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Dependencia>>>().Result;
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
