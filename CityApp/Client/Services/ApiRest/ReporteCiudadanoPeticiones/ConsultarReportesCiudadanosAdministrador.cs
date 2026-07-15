using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones
{
    public class ConsultarReportesCiudadanosAdministrador
    {
        private HttpClient Cliente;
        public ConsultarReportesCiudadanosAdministrador(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<ReporteCiudadano>>> ConsultarReportesCiudadanosAdministradorAsync(string token, FiltroReportesCiudadanos filtroReportesCiudadanos)
        {
            Response<List<ReporteCiudadano>> response = new Response<List<ReporteCiudadano>>();

            string url = "ReporteCiudadano/ConsultarReportesCiudadanosAdministrador";
            Peticion<FiltroReportesCiudadanos> peticion = new Peticion<FiltroReportesCiudadanos>();
            peticion.Token = token;
            peticion.Data = filtroReportesCiudadanos;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroReportesCiudadanos>>(url, peticion);
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
