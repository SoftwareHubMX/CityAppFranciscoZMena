using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CuentaPeticiones
{
    public class ActualizarPasswordPeticiones
    {
        private HttpClient Cliente;
        public ActualizarPasswordPeticiones(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarPasswordAsync(ActualizarPassword actualizarPassword)
        {
            Response<object> response = new Response<object>();

            string url = "Cuenta/ActualizarPassword";
            Peticion<ActualizarPassword> peticion = new Peticion<ActualizarPassword>();
            peticion.Data = actualizarPassword;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<ActualizarPassword>>(url, peticion);
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
