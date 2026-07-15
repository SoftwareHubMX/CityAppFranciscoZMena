using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DirectorioPeticiones
{
    public class EliminarDirectorio
    {
        private HttpClient Cliente;
        public EliminarDirectorio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarDirectorioAsync(string token, int idDirectorio)
        {
            Response<object> response = new Response<object>();

            string url = "Directorio/EliminarDirectorio";
            Peticion<object> peticion = new Peticion<object>();
            peticion.Token = token;
            peticion.Data = idDirectorio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
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
