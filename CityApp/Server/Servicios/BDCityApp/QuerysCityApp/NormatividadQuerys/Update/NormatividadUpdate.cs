using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys.Update
{
    public class NormatividadUpdate
    {
        private UpdateCityApp<Normatividad> UpdateCityApp;

        public NormatividadUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Normatividad>(cityAppContext);
        }

        public Response<object> UpdateNormatividad(Normatividad Normatividad)
        {
            return UpdateCityApp.Save(Normatividad);
        }
    }
}
