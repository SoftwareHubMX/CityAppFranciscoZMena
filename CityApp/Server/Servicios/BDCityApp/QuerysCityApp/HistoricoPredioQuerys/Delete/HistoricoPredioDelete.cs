using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys.Delete
{
    public class HistoricoPredioDelete
    {
        private DeleteCityApp<HistoricoPredio> DeleteCityApp;

        public HistoricoPredioDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<HistoricoPredio>(cityAppContext);
        }

        public Response<object> DeleteHistoricoPredio(HistoricoPredio HistoricoPredio)
        {
            return DeleteCityApp.Save(HistoricoPredio);
        }
    }
}
