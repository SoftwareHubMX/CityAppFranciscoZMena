using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys.Insert
{
    public class ArchivoSliderInsert
    {
        private InsertCityApp<ArchivoSlider> InsertCityApp;

        public ArchivoSliderInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ArchivoSlider>(cityAppContext);
        }

        public Response<object> InsertArchivoSlider(ArchivoSlider ArchivoSlider)
        {
            return InsertCityApp.Save(ArchivoSlider);
        }
    }
}
