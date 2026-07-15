using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PredioPeticiones
{
    public class CrearPredioPeticiones
    {
        private HttpClient Cliente;
        public CrearPredioPeticiones(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearPredioAsync(string token, CrearPredio crearPredio)
        {
            Response<int> response = new Response<int>();

            string url = "Predio/CrearPredio";
            Peticion<CrearPredio> peticion = new Peticion<CrearPredio>();
            peticion.Token = token;
            peticion.Data = crearPredio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<CrearPredio>>(url, peticion);
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
