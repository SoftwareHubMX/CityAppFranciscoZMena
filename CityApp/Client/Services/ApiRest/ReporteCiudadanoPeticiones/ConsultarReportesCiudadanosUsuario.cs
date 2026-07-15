using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones
{
    public class ConsultarReportesCiudadanosUsuario
    {
        private HttpClient Cliente;
        public ConsultarReportesCiudadanosUsuario(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<ReporteCiudadano>>> ConsultarReportesCiudadanosUsuarioAsync(string token)
        {
            Response<List<ReporteCiudadano>> response = new Response<List<ReporteCiudadano>>();

            string url = "ReporteCiudadano/ConsultarReportesCiudadanosUsuario";
            Peticion<object> peticion = new Peticion<object>();
            peticion.Token = token;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<ReporteCiudadano>>>().Result;
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
