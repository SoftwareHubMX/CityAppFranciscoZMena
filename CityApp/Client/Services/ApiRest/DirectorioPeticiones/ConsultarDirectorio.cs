using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DirectorioPeticiones
{
    public class ConsultarDirectorio
    {
        private HttpClient Cliente;
        public ConsultarDirectorio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Directorio>> ConsultarDirectorioAsync(int idDirectorio)
        {
            Response<Directorio> response = new Response<Directorio>();

            string url = "Directorio/ConsultarDirectorio";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idDirectorio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Directorio>>().Result;
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
