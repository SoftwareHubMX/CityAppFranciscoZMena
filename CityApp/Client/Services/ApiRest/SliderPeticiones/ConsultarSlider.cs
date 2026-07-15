using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.SliderPeticiones
{
    public class ConsultarSlider
    {
        private HttpClient Cliente;
        public ConsultarSlider(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<Slider>> ConsultarSliderAsync(int idSlider)
        {
            Response<Slider> response = new Response<Slider>();

            string url = "Slider/ConsultarSlider";
            Peticion<int> peticion = new Peticion<int>();
            peticion.Data = idSlider;
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<int>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<Slider>>().Result;
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
