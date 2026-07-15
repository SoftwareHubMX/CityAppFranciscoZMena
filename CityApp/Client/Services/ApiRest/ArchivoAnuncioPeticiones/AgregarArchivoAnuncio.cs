using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoAnuncioPeticiones
{
    public class AgregarArchivoAnuncio
    {
        private HttpClient Cliente;
        public AgregarArchivoAnuncio(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<string>> AgregarArchivoAnuncioAsync(MultipartFormDataContent content, int idAnuncio, string token)
        {
            Response<string> response = new Response<string>();
            Peticion<object> peticion = new Peticion<object>();

            var responsePeticion = await Cliente.PostAsync("ArchivoAnuncio/AgregarArchivoAnuncio/" + idAnuncio + "/" + token, content);

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
