using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.PatrullaPeticiones
{
    public class ConsultarPatrullas
    {
        private HttpClient Cliente;
        public ConsultarPatrullas(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<Patrulla>>> ConsultarPatrullasAsync(string token, FiltroPatrullas FiltroPatrullas)
        {
            Response<List<Patrulla>> response = new Response<List<Patrulla>>();

            string url = "Patrulla/ConsultarPatrullas";
            Peticion<FiltroPatrullas> peticion = new Peticion<FiltroPatrullas>();
            peticion.Token = token;
            peticion.Data = FiltroPatrullas;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<FiltroPatrullas>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<Patrulla>>>().Result;
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
