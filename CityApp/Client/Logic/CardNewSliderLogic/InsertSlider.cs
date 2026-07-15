using CityApp.Client.Services.ApiRest.SliderPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewSliderLogic
{
    public class InsertSlider
    {
        private SliderPeticiones SliderPeticiones;

        public InsertSlider(HttpClient cliente)
        {
            SliderPeticiones = new SliderPeticiones(cliente);
        }

        public async Task<Response<int>> Insert(string token, Slider slider)
        {
            Response<int> response = await SliderPeticiones.crearSlider(token, slider);
            return response;
        }
    }
}
