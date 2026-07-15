using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys.Insert
{
    public class PatrullaInsert
    {
        private InsertCityApp<Patrulla> InsertCityApp;

        public PatrullaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Patrulla>(cityAppContext);
        }

        public Response<object> InsertPatrulla(Patrulla Patrulla)
        {
            return InsertCityApp.Save(Patrulla);
        }
    }
}
