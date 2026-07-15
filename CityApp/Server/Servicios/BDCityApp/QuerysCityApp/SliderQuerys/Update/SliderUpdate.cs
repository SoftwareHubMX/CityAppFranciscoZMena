using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys.Update
{
    public class SliderUpdate
    {
        private UpdateCityApp<Slider> UpdateCityApp;

        public SliderUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Slider>(cityAppContext);
        }

        public Response<object> UpdateSlider(Slider Slider)
        {
            return UpdateCityApp.Save(Slider);
        }
    }
}
