using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys.Delete
{
    public class ArchivoSliderDelete
    {
        private DeleteCityApp<ArchivoSlider> DeleteCityApp;

        public ArchivoSliderDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoSlider>(cityAppContext);
        }

        public Response<object> DeleteArchivoSlider(ArchivoSlider ArchivoSlider)
        {
            return DeleteCityApp.Save(ArchivoSlider);
        }
    }
}
