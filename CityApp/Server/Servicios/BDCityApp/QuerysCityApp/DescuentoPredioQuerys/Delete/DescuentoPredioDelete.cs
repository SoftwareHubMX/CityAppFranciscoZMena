using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys.Delete
{
    public class DescuentoPredioDelete
    {
        private DeleteCityApp<DescuentoPredio> DeleteCityApp;

        public DescuentoPredioDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<DescuentoPredio>(cityAppContext);
        }

        public Response<object> DeleteDescuentoPredio(DescuentoPredio DescuentoPredio)
        {
            return DeleteCityApp.Save(DescuentoPredio);
        }
    }
}
