using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys.Update
{
    public class PredioUpdate
    {
        private UpdateCityApp<Predio> UpdateCityApp;

        public PredioUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Predio>(cityAppContext);
        }

        public Response<object> UpdatePredio(Predio Predio)
        {
            return UpdateCityApp.Save(Predio);
        }
    }
}
