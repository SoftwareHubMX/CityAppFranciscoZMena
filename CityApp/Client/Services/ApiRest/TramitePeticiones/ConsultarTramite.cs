using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TramitePeticiones
{
    public class ConsultarTramite
    {
        private HttpClient Cliente;
        public ConsultarTramite(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Tramite>> ConsultarTramiteAsync(string token, int idTramite)
        {
            Response<Tramite> response = new Response<Tramite>();

            string url = "Tramite/ConsultarTramite";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idTramite;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Tramite>>().Result;
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
