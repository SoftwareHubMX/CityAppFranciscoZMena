using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones
{
    public class ConsultarReporteCiudadanoCompletoAdministrador
    {
        private HttpClient Cliente;
        public ConsultarReporteCiudadanoCompletoAdministrador(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<ReporteCiudadano>> ConsultarReporteCiudadanoCompletoAdministradorAsync(string token, int idReporteCiudadano)
        {
            Response<ReporteCiudadano> response = new Response<ReporteCiudadano>();

            string url = "ReporteCiudadano/ConsultarReporteCiudadanoCompletoAdministrador";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idReporteCiudadano;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<ReporteCiudadano>>().Result;
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
