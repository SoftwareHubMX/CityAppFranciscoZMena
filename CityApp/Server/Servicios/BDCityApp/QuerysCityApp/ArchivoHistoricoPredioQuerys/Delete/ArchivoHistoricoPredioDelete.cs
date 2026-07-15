using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys.Delete
{
    public class ArchivoHistoricoPredioDelete
    {
        private DeleteCityApp<ArchivoHistoricoPredio> DeleteCityApp;

        public ArchivoHistoricoPredioDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoHistoricoPredio>(cityAppContext);
        }

        public Response<object> DeleteArchivoHistoricoPredio(ArchivoHistoricoPredio ArchivoHistoricoPredio)
        {
            return DeleteCityApp.Save(ArchivoHistoricoPredio);
        }
    }
}
