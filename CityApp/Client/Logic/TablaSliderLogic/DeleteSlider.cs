using CityApp.Client.Services.ApiRest.SliderPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaSliderLogic
{
    public class DeleteSlider
    {
        private SliderPeticiones SliderPeticiones;

        public DeleteSlider(HttpClient cliente)
        {
            SliderPeticiones = new SliderPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idSlider)
        {
            Response<object> response = await SliderPeticiones.eliminarSlider(token, idSlider);
            return response;
        }
    }
}
