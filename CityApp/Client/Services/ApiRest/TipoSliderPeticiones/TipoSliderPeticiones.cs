using CityApp.Client.Services.ApiRest.TipoSliderPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TipoSliderPeticiones
{
    public class TipoSliderPeticiones
    {
        private ConsultarTiposSliders ConsultarTiposSliders;

        public TipoSliderPeticiones(HttpClient cliente)
        {
            ConsultarTiposSliders = new ConsultarTiposSliders(cliente);
        }

        public async Task<Response<List<TipoSlider>>> consultarTiposSliders()
        {
            Response<List<TipoSlider>> response = await ConsultarTiposSliders.ConsultarTiposSlidersAsync();
            return response;
        }
    }
}
