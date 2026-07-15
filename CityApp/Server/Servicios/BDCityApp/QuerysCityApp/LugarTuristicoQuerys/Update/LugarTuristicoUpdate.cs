using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys.Update
{
    public class LugarTuristicoUpdate
    {
        private UpdateCityApp<LugarTuristico> UpdateCityApp;

        public LugarTuristicoUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<LugarTuristico>(cityAppContext);
        }

        public Response<object> UpdateLugarTuristico(LugarTuristico lugarTuristico)
        {
            return UpdateCityApp.Save(lugarTuristico);
        }
    }
}
