using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CuentaPeticiones
{
    public class RecuperarPasswordPeticiones
    {
        private HttpClient Cliente;
        public RecuperarPasswordPeticiones(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> RecuperarPasswordAsync(RecuperacionPassword recuperacionPassword)
        {
            Response<object> response = new Response<object>();

            string url = "Cuenta/RecuperarPassword";
            Peticion<RecuperacionPassword> peticion = new Peticion<RecuperacionPassword>();
            peticion.Data = recuperacionPassword;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<RecuperacionPassword>>(url, peticion);
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
