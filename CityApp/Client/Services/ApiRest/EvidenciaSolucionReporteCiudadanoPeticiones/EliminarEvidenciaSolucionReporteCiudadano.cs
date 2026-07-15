using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.EvidenciaSolucionReporteCiudadanoPeticiones
{
    public class EliminarEvidenciaSolucionReporteCiudadano
    {
        private HttpClient Cliente;
        public EliminarEvidenciaSolucionReporteCiudadano(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarEvidenciaSolucionReporteCiudadanoAsync(string token, int idEvidenciaSolucionReporteCiudadano)
        {
            Response<object> response = new Response<object>();

            string url = "EvidenciaSolucionReporteCiudadano/EliminarEvidenciaSolucionReporteCiudadano";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idEvidenciaSolucionReporteCiudadano;
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
