using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PagoPeticiones
{
    public class EliminarPago
    {
        private HttpClient Cliente;
        public EliminarPago(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarPagoAsync(int idPago, string token)
        {
            Response<object> response = new Response<object>();

            string url = "Pago/EliminarPago";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idPago;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
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
