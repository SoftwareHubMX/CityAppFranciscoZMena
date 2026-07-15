using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys.Delete
{
    public class SliderDelete
    {
        private DeleteCityApp<Slider> DeleteCityApp;

        public SliderDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Slider>(cityAppContext);
        }

        public Response<object> DeleteSlider(Slider Slider)
        {
            return DeleteCityApp.Save(Slider);
        }
    }
}
