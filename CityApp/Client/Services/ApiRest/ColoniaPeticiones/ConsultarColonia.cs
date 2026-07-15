using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ColoniaPeticiones
{
    public class ConsultarColonia
    {
        private HttpClient Cliente;
        public ConsultarColonia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Colonia>> ConsultarColoniaAsync(string token, int idColonia)
        {
            Response<Colonia> response = new Response<Colonia>();

            string url = "Colonia/ConsultarColonia";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idColonia;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Colonia>>().Result;
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
