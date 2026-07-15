using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys.Update
{
    public class HistoricoPredioUpdate
    {
        private UpdateCityApp<HistoricoPredio> UpdateCityApp;

        public HistoricoPredioUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<HistoricoPredio>(cityAppContext);
        }

        public Response<object> UpdateHistoricoPredio(HistoricoPredio HistoricoPredio)
        {
            return UpdateCityApp.Save(HistoricoPredio);
        }
    }
}
