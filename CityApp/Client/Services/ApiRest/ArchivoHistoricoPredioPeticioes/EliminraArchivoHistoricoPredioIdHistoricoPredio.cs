using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoHistoricoPredioPeticioes
{
    public class EliminraArchivoHistoricoPredioIdHistoricoPredio
    {
        private HttpClient Cliente;
        public EliminraArchivoHistoricoPredioIdHistoricoPredio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminraArchivoHistoricoPredioIdHistoricoPredioAsync(string token, int idHistoricoPredio)
        {
            Response<object> response = new Response<object>();

            string url = "ArchivoHistoricoPredio/EliminraArchivoHistoricoPredioIdHistoricoPredio";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idHistoricoPredio;
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
