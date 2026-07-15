using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones
{
    public class ActualizarEstatusReporteCiudadano
    {
        private HttpClient Cliente;
        public ActualizarEstatusReporteCiudadano(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> ActualizarEstatusReporteCiudadanoAsync(string token, int idEstatusReporteCiudadano, int idReporteCiudadano)
        {
            Response<object> response = new Response<object>();

            string url = "ReporteCiudadano/ActualizarEstatusReporteCiudadano";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Identificador = idReporteCiudadano.ToString();
            peticion.Data = idEstatusReporteCiudadano;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
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
