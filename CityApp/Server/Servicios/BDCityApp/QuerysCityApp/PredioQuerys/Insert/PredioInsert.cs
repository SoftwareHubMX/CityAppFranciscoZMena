using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys.Insert
{
    public class PredioInsert
    {
        private InsertCityApp<Predio> InsertCityApp;

        public PredioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Predio>(cityAppContext);
        }

        public Response<object> InsertPredio(Predio predio)
        {
            return InsertCityApp.Save(predio);
        }
    }
}
