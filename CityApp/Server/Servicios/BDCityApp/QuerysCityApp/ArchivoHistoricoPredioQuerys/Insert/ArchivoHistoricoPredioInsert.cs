using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys.Insert
{
    public class ArchivoHistoricoPredioInsert
    {
        private InsertCityApp<ArchivoHistoricoPredio> InsertCityApp;

        public ArchivoHistoricoPredioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ArchivoHistoricoPredio>(cityAppContext);
        }

        public Response<object> InsertArchivoHistoricoPredio(ArchivoHistoricoPredio ArchivoHistoricoPredio)
        {
            return InsertCityApp.Save(ArchivoHistoricoPredio);
        }
    }
}
