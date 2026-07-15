using CityApp.Shared.Models.ControllersModels.PredioSalidaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PredioPeticiones
{
    public class ConsultarPredioPago
    {
        private HttpClient Cliente;
        public ConsultarPredioPago(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<InformacionPagoPredio>> ConsultarPredioPagoAsync(int idPredio, string token)
        {
            Response<InformacionPagoPredio> response = new Response<InformacionPagoPredio>();

            string url = "Predio/ConsultarPredioPago";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idPredio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<InformacionPagoPredio>>().Result;
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
