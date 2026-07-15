using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TipoTramitePeticiones
{
    public class ConsultarTiposTramites
    {
        private HttpClient Cliente;
        public ConsultarTiposTramites(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<TipoTramite>>> ConsultarTiposTramitesAsync()
        {
            Response<List<TipoTramite>> response = new Response<List<TipoTramite>>();

            string url = "TipoTramite/ConsultarTiposTramites";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<TipoTramite>>>().Result;
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
