using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys.Insert
{
    public class HistoricoPredioInsert
    {
        private InsertCityApp<HistoricoPredio> InsertCityApp;

        public HistoricoPredioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<HistoricoPredio>(cityAppContext);
        }

        public Response<object> InsertHistoricoPredio(HistoricoPredio HistoricoPredio)
        {
            return InsertCityApp.Save(HistoricoPredio);
        }
    }
}
