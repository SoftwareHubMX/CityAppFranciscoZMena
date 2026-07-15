using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TokenActualizarPasswordPeticiones
{
    public class CrearTokenActualizarPassword
    {
        private HttpClient Cliente;
        public CrearTokenActualizarPassword(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearTokenActualizarPasswordAsync(string correo)
        {
            Response<object> response = new Response<object>();

            string url = "TokenActualizarPassword/CrearTokenActualizarPassword";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Data = correo;
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
