using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.DirectorioPeticiones
{
    public class EditarDirectorio
    {
        private HttpClient Cliente;
        public EditarDirectorio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EditarDirectorioAsync(string token, Directorio directorio)
        {
            Response<object> response = new Response<object>();

            string url = "Directorio/EditarDirectorio";
            Peticion<Directorio> peticion = new Peticion<Directorio>();
            peticion.Token = token;
            peticion.Data = directorio;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Directorio>>(url, peticion);
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
