using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.EvidenciaSolucionReporteCiudadanoPeticiones
{
    public class DescargarEvidenciaSolucionReporteCiudadano
    {
        private HttpClient Cliente;
        public DescargarEvidenciaSolucionReporteCiudadano(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<byte[]>> DescargarEvidenciaSolucionReporteCiudadanoAsync(string imagen, string token, int idReporteCiudadno)
        {
            Response<byte[]> response = new Response<byte[]>();

            string url = "EvidenciaSolucionReporteCiudadano/DescargarEvidenciaSolucionReporteCiudadano";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Token = token;
            peticion.Identificador = idReporteCiudadno.ToString();
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
