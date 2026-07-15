using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PagoPeticiones
{
    public class ActualizarPago
    {
        private HttpClient Cliente;
        public ActualizarPago(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarPagoAsync(string token, Pago pago)
        {
            Response<object> response = new Response<object>();

            string url = "Pago/ActualizarPago";
            Peticion<Pago> peticion = new Peticion<Pago>();
            peticion.Token = token;
            peticion.Data = pago;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Pago>>(url, peticion);
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
