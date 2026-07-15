using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContadorAccesoQuerys.Update
{
    public class ContadorAccesoUpdate
    {
        private UpdateCityApp<ContadorAcceso> UpdateCityApp;

        public ContadorAccesoUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<ContadorAcceso>(cityAppContext);
        }

        public Response<object> UpdateContadorAcceso(ContadorAcceso contadorAcceso)
        {
            return UpdateCityApp.Save(contadorAcceso);
        }
    }
}
