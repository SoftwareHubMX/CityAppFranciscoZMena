using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoHistoricoPredioPeticioes
{
    public class DescargarArchivoHistoricoPredio
    {
        private HttpClient Cliente;
        public DescargarArchivoHistoricoPredio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<byte[]>> DescargarArchivoHistoricoPredioAsync(string imagen, int idNotocia)
        {
            Response<byte[]> response = new Response<byte[]>();

            string url = "ArchivoHistoricoPredio/DescargarArchivoHistoricoPredio";
            Peticion<string> peticion = new Peticion<string>();
            peticion.Data = imagen;
            peticion.Identificador = idNotocia.ToString();

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
