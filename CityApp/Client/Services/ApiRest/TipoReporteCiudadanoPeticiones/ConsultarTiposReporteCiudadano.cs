using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TipoReporteCiudadanoPeticiones
{
    public class ConsultarTiposReporteCiudadano
    {
        private HttpClient Cliente;
        public ConsultarTiposReporteCiudadano(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<TipoReporteCiudadano>>> ConsultarTiposReporteCiudadanoAsync()
        {
            Response<List<TipoReporteCiudadano>> response = new Response<List<TipoReporteCiudadano>>();

            string url = "TipoReporteCiudadano/ConsultarTiposReporteCiudadano";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<TipoReporteCiudadano>>>().Result;
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
