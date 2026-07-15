using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.EvidenciaSolucionReporteCiudadanoPeticiones
{
    public class AgregarEvidenciaSolucionReporteCiudadano
    {
        private HttpClient Cliente;
        public AgregarEvidenciaSolucionReporteCiudadano(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<string>> AgregarEvidenciaSolucionReporteCiudadanoAsync(MultipartFormDataContent content, int idReporteCiudadano, string token)
        {
            Response<string> response = new Response<string>();
            Peticion<object> peticion = new Peticion<object>();

            var responsePeticion = await Cliente.PostAsync("EvidenciaSolucionReporteCiudadano/AgregarEvidenciaSolucionReporteCiudadano/" + idReporteCiudadano + "/" + token, content);

            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<string>>().Result;
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
