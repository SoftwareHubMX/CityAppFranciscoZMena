using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys.Delete
{
    public class CaracteristicaLugarTuristicoDelete
    {
        private DeleteCityApp<CaracteristicaLugarTuristico> DeleteCityApp;

        public CaracteristicaLugarTuristicoDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<CaracteristicaLugarTuristico>(cityAppContext);
        }

        public Response<object> DeleteCaracteristicaLugarTuristico(CaracteristicaLugarTuristico caracteristicaLugarTuristico)
        {
            return DeleteCityApp.Save(caracteristicaLugarTuristico);
        }
    }
}
