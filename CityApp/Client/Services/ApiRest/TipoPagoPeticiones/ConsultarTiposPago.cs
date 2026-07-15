using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TipoPagoPeticiones
{
    public class ConsultarTiposPago
    {
        private HttpClient Cliente;
        public ConsultarTiposPago(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<TipoPago>>> ConsultarTiposPagoAsync()
        {
            Response<List<TipoPago>> response = new Response<List<TipoPago>>();

            string url = "TipoPago/ConsultarTiposPago";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<TipoPago>>>().Result;
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
