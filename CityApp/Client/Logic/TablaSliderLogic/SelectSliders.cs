using CityApp.Client.Services.ApiRest.SliderPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaSliderLogic
{
    public class SelectSliders
    {
        private SliderPeticiones SliderPeticiones;

        public SelectSliders(HttpClient cliente)
        {
            SliderPeticiones = new SliderPeticiones(cliente);
        }

        public async Task<Response<List<Slider>>> SelectAll()
        {
            Response<List<Slider>> response = await SliderPeticiones.consultarSliders();
            return response;
        }
    }
}
