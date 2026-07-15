using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.TramiteEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TramitePeticiones
{
    public class ConsultarTramitesFiltro
    {
        private HttpClient Cliente;
        public ConsultarTramitesFiltro(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Tramite>>> ConsultarTramitesFiltroAsync(string token, FiltroTramite filtroTramite)
        {
            Response<List<Tramite>> response = new Response<List<Tramite>>();

            string url = "Tramite/ConsultarTramitesFiltro";
            Peticion<FiltroTramite> peticion = new Peticion<FiltroTramite>();
            peticion.Token = token;
            peticion.Data = filtroTramite;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroTramite>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Tramite>>>().Result;
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
