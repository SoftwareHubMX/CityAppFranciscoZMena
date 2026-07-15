using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DirectorioPeticiones
{
    public class CrearDirectorio
    {
        private HttpClient Cliente;
        public CrearDirectorio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearDirectorioAsync(string token, Directorio directorio)
        {
            Response<int> response = new Response<int>();

            string url = "Directorio/CrearDirectorio";
            Peticion<Directorio> peticion = new Peticion<Directorio>();
            peticion.Token = token;
            peticion.Data = directorio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Directorio>>(url, peticion);
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
