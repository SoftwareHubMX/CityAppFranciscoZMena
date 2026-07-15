using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoNoticiaPeticiones
{
    public class AgregarArchivoNoticia
    {
        private HttpClient Cliente;
        public AgregarArchivoNoticia(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<string>> AgregarArchivoNoticiaAsync(MultipartFormDataContent content, int idNoticia, string token)
        {
            Response<string> response = new Response<string>();
            Peticion<object> peticion = new Peticion<object>();

            var responsePeticion = await Cliente.PostAsync("ArchivoNoticia/AgregarArchivoNoticia/" + idNoticia + "/" + token, content);

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
