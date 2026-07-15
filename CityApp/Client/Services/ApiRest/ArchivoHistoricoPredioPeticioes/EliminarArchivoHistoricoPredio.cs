using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoHistoricoPredioPeticioes
{
    public class EliminarArchivoHistoricoPredio
    {
        private HttpClient Cliente;
        public EliminarArchivoHistoricoPredio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarArchivoHistoricoPredioAsync(string token, int idArchivoHistoricoPredio)
        {
            Response<object> response = new Response<object>();

            string url = "ArchivoHistoricoPredio/EliminarArchivoHistoricoPredio";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idArchivoHistoricoPredio;
            peticion.Token = token;

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
