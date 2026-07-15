using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys.Insert
{
    public class ColoniaInsert
    {
        private InsertCityApp<Colonia> InsertCityApp;

        public ColoniaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Colonia>(cityAppContext);
        }

        public Response<object> InsertColonia(Colonia colonia)
        {
            return InsertCityApp.Save(colonia);
        }
    }
}
