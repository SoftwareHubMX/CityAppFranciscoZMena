using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.EvidenciaReporteCiudadanoPeticiones
{
    public class EliminarEvidenciaReporteCiudadano
    {
        private HttpClient Cliente;
        public EliminarEvidenciaReporteCiudadano(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarEvidenciaReporteCiudadanoAsync(string token, int idEvidenciaReporteCiudadano)
        {
            Response<object> response = new Response<object>();

            string url = "EvidenciaReporteCiudadano/EliminarEvidenciaReporteCiudadano";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idEvidenciaReporteCiudadano;
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
