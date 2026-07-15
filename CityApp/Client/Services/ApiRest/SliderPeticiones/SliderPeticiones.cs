using CityApp.Client.Services.ApiRest.SliderPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.SliderPeticiones
{
    public class SliderPeticiones
    {
        private CrearSlider CrearSlider;
        private ConsultarSliders ConsultarSliders;
        private ConsultarSlider ConsultarSlider;
        private EliminarSlider EliminarSlider;

        public SliderPeticiones(HttpClient cliente)
        {
            CrearSlider = new CrearSlider(cliente);
            ConsultarSliders = new ConsultarSliders(cliente);
            ConsultarSlider = new ConsultarSlider(cliente);
            EliminarSlider = new EliminarSlider(cliente);
        }

        public async Task<Response<int>> crearSlider(string toke, Slider Slider)
        {
            Response<int> response = await CrearSlider.CrearSliderAsync(toke, Slider);
            return response;
        }

        public async Task<Response<List<Slider>>> consultarSliders()
        {
            Response<List<Slider>> response = await ConsultarSliders.ConsultarSlidersAsync();
            return response;
        }

        public async Task<Response<Slider>> consultarSlider(int idSlider)
        {
            Response<Slider> response = await ConsultarSlider.ConsultarSliderAsync(idSlider);
            return response;
        }

        public async Task<Response<object>> eliminarSlider(string toke, int idSlider)
        {
            Response<object> response = await EliminarSlider.EliminarSliderAsync(toke, idSlider);
            return response;
        }
    }
}
