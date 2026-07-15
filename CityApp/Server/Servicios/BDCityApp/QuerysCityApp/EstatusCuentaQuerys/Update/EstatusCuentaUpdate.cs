using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusCuentaQuerys.Update
{
    public class EstatusCuentaUpdate
    {
        private UpdateCityApp<EstatusCuenta> UpdateCityApp;

        public EstatusCuentaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<EstatusCuenta>(cityAppContext);
        }

        public Response<object> UpdateEstatusCuenta(EstatusCuenta estatusCuenta)
        {
            return UpdateCityApp.Save(estatusCuenta);
        }
    }
}
