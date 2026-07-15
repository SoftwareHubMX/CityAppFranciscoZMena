using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoHistoricoPredioPeticioes
{
    public class EliminarArchivoHistoricoPredioTercero
    {
        private HttpClient Cliente;
        public EliminarArchivoHistoricoPredioTercero(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarArchivoHistoricoPredioTerceroAsync(string token)
        {
            Response<object> response = new Response<object>();

            string url = "ArchivoHistoricoPredio/EliminarArchivoHistoricoPredioTercero";
            Peticion<object> peticion = new Peticion<object>();
            peticion.Token = token;

            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
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
