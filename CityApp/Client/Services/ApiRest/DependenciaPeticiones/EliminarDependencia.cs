using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DependenciaPeticiones
{
    public class EliminarDependencia
    {
        private HttpClient Cliente;
        public EliminarDependencia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarDependenciaAsync(string token, int idDependencia)
        {
            Response<object> response = new Response<object>();

            string url = "Dependencia/EliminarDependencia";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idDependencia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
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
