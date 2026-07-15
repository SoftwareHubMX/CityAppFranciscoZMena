using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CuentaPeticiones
{
    public class CrearCuentaPeticiones
    {
        private HttpClient Cliente;
        public CrearCuentaPeticiones(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearCuentaAsync(CrearCuenta crearCuenta)
        {
            Response<object> response = new Response<object>();

            string url = "Cuenta/CrearCuenta";
            Peticion<CrearCuenta> peticion = new Peticion<CrearCuenta>();
            peticion.Data = crearCuenta;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<CrearCuenta>>(url, peticion);
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
