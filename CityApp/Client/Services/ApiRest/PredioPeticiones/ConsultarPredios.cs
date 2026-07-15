using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PredioPeticiones
{
    public class ConsultarPredios
    {
        private HttpClient Cliente;
        public ConsultarPredios(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Predio>>> ConsultarPrediosAsync(string token, FiltroPredios filtroPredios)
        {
            Response<List<Predio>> response = new Response<List<Predio>>();

            string url = "Predio/ConsultarPredios";
            Peticion<FiltroPredios> peticion = new Peticion<FiltroPredios>();
            peticion.Token = token;
            peticion.Data = filtroPredios;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroPredios>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Predio>>>().Result;
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
