using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DependenciaPeticiones
{
    public class ActualizarDependencia
    {
        private HttpClient Cliente;
        public ActualizarDependencia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarDependenciaAsync(string token, Dependencia dependencia)
        {
            Response<object> response = new Response<object>();

            string url = "Dependencia/ActualizarDependencia";
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
