using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys.Insert
{
    public class LugarTuristicoInsert
    {
        private InsertCityApp<LugarTuristico> InsertCityApp;

        public LugarTuristicoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<LugarTuristico>(cityAppContext);
        }

        public Response<object> InsertLugarTuristico(LugarTuristico lugarTuristico)
        {
            return InsertCityApp.Save(lugarTuristico);
        }
    }
}
