using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoDirectorioPeticiones
{
    public class EliminarArchivoDirectorio
    {
        private HttpClient Cliente;
        public EliminarArchivoDirectorio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarArchivoDirectorioAsync(string token, int idArchivoDirectorio)
        {
            Response<object> response = new Response<object>();

            string url = "ArchivoDirectorio/EliminarArchivoDirectorio";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idArchivoDirectorio;
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
