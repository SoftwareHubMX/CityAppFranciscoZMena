using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CuentaPeticiones
{
    public class ActualizarNombreUsuario
    {
        private HttpClient Cliente;
        public ActualizarNombreUsuario(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarNombreUsuarioAsync(string nombreUsuario)
        {
            Response<object> response = new Response<object>();

            string url = "Cuenta/ActualizarNombreUsuario";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Data = nombreUsuario;
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
