using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.StatusAlertaRutaPeticiones
{
    public class ConsultarStatusAlertaRuta
    {
        private HttpClient Cliente;
        public ConsultarStatusAlertaRuta(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<StatusAlertaRuta>>> ConsultarStatusAlertaRutaAsync()
        {
            Response<List<StatusAlertaRuta>> response = new Response<List<StatusAlertaRuta>>();

            string url = "StatusAlertaRuta/ConsultarStatusAlertaRuta";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<StatusAlertaRuta>>>().Result;
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
