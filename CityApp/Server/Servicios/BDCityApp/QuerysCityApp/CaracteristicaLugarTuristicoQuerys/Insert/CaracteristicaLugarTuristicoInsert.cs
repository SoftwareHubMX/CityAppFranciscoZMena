using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys.Insert
{
    public class CaracteristicaLugarTuristicoInsert
    {
        private InsertCityApp<CaracteristicaLugarTuristico> InsertCityApp;

        public CaracteristicaLugarTuristicoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<CaracteristicaLugarTuristico>(cityAppContext);
        }

        public Response<object> InsertCaracteristicaLugarTuristico(CaracteristicaLugarTuristico caracteristicaLugarTuristico)
        {
            return InsertCityApp.Save(caracteristicaLugarTuristico);
        }
    }
}
