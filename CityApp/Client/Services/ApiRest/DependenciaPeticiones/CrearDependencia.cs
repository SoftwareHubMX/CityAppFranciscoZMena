using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DependenciaPeticiones
{
    public class CrearDependencia
    {
        private HttpClient Cliente;
        public CrearDependencia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearDependenciaAsync(string token, Dependencia dependencia)
        {
            Response<object> response = new Response<object>();

            string url = "Dependencia/CrearDependencia";
            Peticion<Dependencia> peticion = new Peticion<Dependencia>();
            peticion.Token = token;
            peticion.Data = dependencia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Dependencia>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<object>>().Result;
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
