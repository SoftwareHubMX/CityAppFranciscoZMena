using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoSliderPeticioens
{
    public class AgregarArchivoSlider
    {
        private HttpClient Cliente;
        public AgregarArchivoSlider(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<string>> AgregarArchivoSliderAsync(MultipartFormDataContent content, int idSlider, string token)
        {
            Response<string> response = new Response<string>();
            Peticion<object> peticion = new Peticion<object>();

            var responsePeticion = await Cliente.PostAsync("ArchivoSlider/AgregarArchivoSlider/" + idSlider + "/" + token, content);

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
