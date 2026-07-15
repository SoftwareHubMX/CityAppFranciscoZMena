using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys.Insert
{
    public class NormatividadInsert
    {
        private InsertCityApp<Normatividad> InsertCityApp;

        public NormatividadInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Normatividad>(cityAppContext);
        }

        public Response<object> InsertNormatividad(Normatividad Normatividad)
        {
            return InsertCityApp.Save(Normatividad);
        }
    }
}
