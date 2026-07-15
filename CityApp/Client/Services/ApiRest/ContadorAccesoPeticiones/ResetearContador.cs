using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ContadorAccesoPeticiones
{
    public class ResetearContador
    {
        private HttpClient Cliente;
        public ResetearContador(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ResetearContadorAsync(string token)
        {
            Response<object> response = new Response<object>();

            string url = "ContadorAcceso/ResetearContador";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Data = token;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<string>>(url, peticion);
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
