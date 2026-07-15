using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.AlertaRutaPeticiones
{
    public class ActualizarStatusAlertaRutaAdmin
    {
        private HttpClient Cliente;
        public ActualizarStatusAlertaRutaAdmin(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarStatusAlertaRutaAsync(string token, int idAlertaRuta, int idStatusAlertaRuta)
        {
            Response<object> response = new Response<object>();

            string url = "AlertaRuta/ActualizarStatusAlertaRuta";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Identificador = idAlertaRuta.ToString();
            peticion.Data = idStatusAlertaRuta;
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
