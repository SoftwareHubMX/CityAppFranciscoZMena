using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.EvidenciaReporteCiudadanoPeticiones
{
    public class DescargarEvidenciaReporteCiudadano
    {
        private HttpClient Cliente;
        public DescargarEvidenciaReporteCiudadano(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<byte[]>> DescargarEvidenciaReporteCiudadanoAsync(string imagen, string token, int idVercionReporte)
        {
            Response<byte[]> response = new Response<byte[]>();

            string url = "EvidenciaReporteCiudadano/DescargarEvidenciaReporteCiudadano";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Token = token;
            peticion.Identificador = idVercionReporte.ToString();
            peticion.Data = imagen;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<string>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<byte[]>>().Result;
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
