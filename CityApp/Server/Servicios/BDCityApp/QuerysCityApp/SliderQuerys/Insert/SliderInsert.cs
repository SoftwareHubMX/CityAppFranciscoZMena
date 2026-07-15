using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys.Insert
{
    public class SliderInsert
    {
        private InsertCityApp<Slider> InsertCityApp;

        public SliderInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Slider>(cityAppContext);
        }

        public Response<object> InsertSlider(Slider Slider)
        {
            return InsertCityApp.Save(Slider);
        }
    }
}
