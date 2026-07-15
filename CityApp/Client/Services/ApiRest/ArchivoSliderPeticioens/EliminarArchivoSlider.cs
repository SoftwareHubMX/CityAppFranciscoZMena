using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.ArchivoSliderPeticioens
{
    public class EliminarArchivoSlider
    {
        private HttpClient Cliente;
        public EliminarArchivoSlider(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarArchivoSliderAsync(string token, int idArchivoSlider)
        {
            Response<object> response = new Response<object>();

            string url = "ArchivoSlider/EliminarArchivoSlider";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idArchivoSlider;
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
