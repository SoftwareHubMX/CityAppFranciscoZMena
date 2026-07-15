using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TramitePeticiones
{
    public class ActualizarTramite
    {
        private HttpClient Cliente;
        public ActualizarTramite(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarTramiteAsync(string token, Tramite tramite)
        {
            Response<object> response = new Response<object>();

            string url = "Tramite/ActualizarTramite";
            Peticion<Tramite> peticion = new Peticion<Tramite>();
            peticion.Token = token;
            peticion.Data = tramite;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Tramite>>(url, peticion);
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
