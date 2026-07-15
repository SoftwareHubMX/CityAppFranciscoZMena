using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoDirectorioPeticiones
{
    public class AgregarArchivoDirectorio
    {
        private HttpClient Cliente;
        public AgregarArchivoDirectorio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<string>> AgregarArchivoDirectorioAsync(MultipartFormDataContent content, int idDirectorio, string token)
        {
            Response<string> response = new Response<string>();
            Peticion<object> peticion = new Peticion<object>();

            var responsePeticion = await Cliente.PostAsync("ArchivoDirectorio/AgregarArchivoDirectorio/" + idDirectorio + "/" + token, content);

            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<string>>().Result;
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
