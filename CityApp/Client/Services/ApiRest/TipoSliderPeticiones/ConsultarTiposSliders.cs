using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using System.Net.Http.Json;

namespace CityApp.Client.Services.ApiRest.TipoSliderPeticiones
{
    public class ConsultarTiposSliders
    {
        private HttpClient Cliente;
        public ConsultarTiposSliders(HttpClient cliente)
        {
            Cliente = cliente;
        }

        public async Task<Response<List<TipoSlider>>> ConsultarTiposSlidersAsync()
        {
            Response<List<TipoSlider>> response = new Response<List<TipoSlider>>();

            string url = "TipoSlider/ConsultarTiposSliders";
            Peticion<object> peticion = new Peticion<object>();
            var responsePeticion = await Cliente.PostAsJsonAsync<Peticion<object>>(url, peticion);
            if (responsePeticion.IsSuccessStatusCode)
            {
                response = responsePeticion.Content.ReadFromJsonAsync<Response<List<TipoSlider>>>().Result;
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
