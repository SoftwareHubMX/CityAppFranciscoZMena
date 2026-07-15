using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys.Delete
{
    public class LugarTuristicoDelete
    {
        private DeleteCityApp<LugarTuristico> DeleteCityApp;

        public LugarTuristicoDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<LugarTuristico>(cityAppContext);
        }

        public Response<object> DeleteLugarTuristico(LugarTuristico LugarTuristico)
        {
            return DeleteCityApp.Save(LugarTuristico);
        }
    }
}
