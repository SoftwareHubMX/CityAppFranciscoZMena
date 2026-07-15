using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones
{
    public class ActualizacionObservacionesReporte
    {
        private HttpClient Cliente;
        public ActualizacionObservacionesReporte(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizacionObservacionesReporteAsync(string token, string observaciones, int idReporteCiudadano)
        {
            Response<object> response = new Response<object>();

            string url = "ReporteCiudadano/ActualizacionObservacionesReporteCiudadano";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Token = token;
            peticion.Identificador = idReporteCiudadano.ToString();
            peticion.Data = observaciones;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<string>>(url, peticion);
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
