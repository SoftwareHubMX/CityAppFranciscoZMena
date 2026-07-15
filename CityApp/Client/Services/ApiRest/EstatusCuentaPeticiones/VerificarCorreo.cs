using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.EstatusCuentaPeticiones
{
    public class VerificarCorreo
    {
        private HttpClient Cliente;
        public VerificarCorreo(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> VerificarCorreoAsync(string token)
        {
            Response<object> response = new Response<object>();

            string url = "EstatusCuenta/VerificarCorreo";
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
