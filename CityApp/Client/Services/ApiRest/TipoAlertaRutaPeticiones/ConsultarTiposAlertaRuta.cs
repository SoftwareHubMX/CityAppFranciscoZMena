using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TipoAlertaRutaPeticiones
{
    public class ConsultarTiposAlertaRuta
    {
        private HttpClient Cliente;
        public ConsultarTiposAlertaRuta(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<TipoAlertaRuta>>> ConsultarTiposAlertaRutaAsync()
        {
            Response<List<TipoAlertaRuta>> response = new Response<List<TipoAlertaRuta>>();

            string url = "TipoAlertaRuta/ConsultarTiposAlertaRuta";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<TipoAlertaRuta>>>().Result;
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
