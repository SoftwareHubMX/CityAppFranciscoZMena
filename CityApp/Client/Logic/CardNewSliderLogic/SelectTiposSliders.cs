using CityApp.Client.Services.ApiRest.TipoSliderPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewSliderLogic
{
    public class SelectTiposSliders
    {
        private TipoSliderPeticiones TipoSliderPeticiones;

        public SelectTiposSliders(HttpClient cliente)
        {
            TipoSliderPeticiones = new TipoSliderPeticiones(cliente);
        }

        public async Task<Response<List<TipoSlider>>> SelectAll()
        {
            Response<List<TipoSlider>> response = await TipoSliderPeticiones.consultarTiposSliders();
            return response;
        }
    }
}
