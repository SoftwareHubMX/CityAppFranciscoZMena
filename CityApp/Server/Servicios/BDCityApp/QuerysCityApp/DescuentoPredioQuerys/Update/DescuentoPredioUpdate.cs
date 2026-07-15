using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys.Update
{
    public class DescuentoPredioUpdate
    {
        private UpdateCityApp<DescuentoPredio> UpdateCityApp;

        public DescuentoPredioUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<DescuentoPredio>(cityAppContext);
        }

        public Response<object> UpdateDescuentoPredio(DescuentoPredio DescuentoPredio)
        {
            return UpdateCityApp.Save(DescuentoPredio);
        }
    }
}
