using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.EstatusReporteCiudadanoPeticiones
{
    public class ConsultarEstatusReporteCiudadano
    {
        private HttpClient Cliente;
        public ConsultarEstatusReporteCiudadano(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<EstatusReporteCiudadano>>> ConsultarEstatusReporteCiudadanoAsync()
        {
            Response<List<EstatusReporteCiudadano>> response = new Response<List<EstatusReporteCiudadano>>();

            string url = "EstatusReporteCiudadano/ConsultarEstatusReporteCiudadano";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<EstatusReporteCiudadano>>>().Result;
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
