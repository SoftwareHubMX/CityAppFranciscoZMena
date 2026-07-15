using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys.Insert
{
    public class DescuentoPredioInsert
    {
        private InsertCityApp<DescuentoPredio> InsertCityApp;

        public DescuentoPredioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<DescuentoPredio>(cityAppContext);
        }

        public Response<object> InsertDescuentoPredio(DescuentoPredio DescuentoPredio)
        {
            return InsertCityApp.Save(DescuentoPredio);
        }
    }
}
