using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.SliderPeticiones
{
    public class CrearSlider
    {
        private HttpClient Cliente;
        public CrearSlider(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<int>> CrearSliderAsync(string token, Slider Slider)
        {
            Response<int> response = new Response<int>();

            string url = "Slider/CrearSlider";
            Peticion<Slider> peticion = new Peticion<Slider>();
            peticion.Token = token;
            peticion.Data = Slider;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<Slider>>(url, peticion);
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
