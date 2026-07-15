using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AlertaRutaPeticiones
{
    public class CrearAlertaRuta
    {
        private HttpClient Cliente;
        public CrearAlertaRuta(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> CrearAlertaRutaAsync(string token, AlertaRuta alertaRuta)
        {
            Response<object> response = new Response<object>();

            string url = "AlertaRuta/CrearAlertaRuta";
            Peticion<AlertaRuta> peticion = new Peticion<AlertaRuta>();
            peticion.Token = token;
            peticion.Data = alertaRuta;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<AlertaRuta>>(url, peticion);
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
