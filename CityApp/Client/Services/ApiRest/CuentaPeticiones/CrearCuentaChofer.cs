using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.CuentaPeticiones
{
    public class CrearCuentaChofer
    {
        private HttpClient Cliente;
        public CrearCuentaChofer(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearCuentaChoferAsync(CrearCuenta crearCuenta)
        {
            Response<object> response = new Response<object>();

            string url = "Cuenta/crearCuentaChofer";
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
