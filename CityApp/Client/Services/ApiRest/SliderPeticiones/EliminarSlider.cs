using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.SliderPeticiones
{
    public class EliminarSlider
    {
        private HttpClient Cliente;
        public EliminarSlider(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<object>> EliminarSliderAsync(string token, int idSlider)
        {
            Response<object> response = new Response<object>();

            string url = "Slider/EliminarSlider";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Token = token;
            peticion.Data = idSlider;
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
