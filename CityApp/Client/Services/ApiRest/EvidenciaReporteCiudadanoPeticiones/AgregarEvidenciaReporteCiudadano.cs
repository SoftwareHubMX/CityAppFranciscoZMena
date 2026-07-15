using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.EvidenciaReporteCiudadanoPeticiones
{
    public class AgregarEvidenciaReporteCiudadano
    {
        private HttpClient Cliente;
        public AgregarEvidenciaReporteCiudadano(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<string>> AgregarEvidenciaReporteCiudadanoAsync(MultipartFormDataContent content, int idReporteCiudadano, string token)
        {
            Response<string> response = new Response<string>();
            Peticion<object> peticion = new Peticion<object>();

            var responsePeticion = await Cliente.PostAsync("EvidenciaReporteCiudadano/AgregarEvidenciaReporteCiudadano/" + idReporteCiudadano + "/" + token, content);

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
