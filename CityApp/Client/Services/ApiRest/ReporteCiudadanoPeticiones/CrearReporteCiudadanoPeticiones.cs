using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones
{
    public class CrearReporteCiudadanoPeticiones
    {
        private HttpClient Cliente;
        public CrearReporteCiudadanoPeticiones(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearReporteCiudadanoAsync(string token, CrearReporteCiudadano crearReporteCiudadano)
        {
            Response<int> response = new Response<int>();

            string url = "ReporteCiudadano/CrearReporteCiudadano";
            Peticion<CrearReporteCiudadano> peticion = new Peticion<CrearReporteCiudadano>();
            peticion.Token = token;
            peticion.Data = crearReporteCiudadano;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<CrearReporteCiudadano>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<int>>().Result;
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
