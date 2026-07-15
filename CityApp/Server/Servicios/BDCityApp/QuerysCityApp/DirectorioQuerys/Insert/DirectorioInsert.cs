using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys.Insert
{
    public class DirectorioInsert
    {
        private InsertCityApp<Directorio> InsertCityApp;

        public DirectorioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Directorio>(cityAppContext);
        }

        public Response<object> InsertDirectorio(Directorio directorio)
        {
            return InsertCityApp.Save(directorio);
        }
    }
}
