using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PagoPeticiones
{
    public class ConsultarPago
    {
        private HttpClient Cliente;
        public ConsultarPago(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Pago>> ConsultarPagoAsync(int idPago, string token)
        {
            Response<Pago> response = new Response<Pago>();

            string url = "Pago/ConsultarPago";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idPago;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Pago>>().Result;
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
