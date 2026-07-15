using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Update
{
    public class CuentaUpdate
    {
        private UpdateCityApp<Cuenta> UpdateCityApp;

        public CuentaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Cuenta>(cityAppContext);
        }

        public Response<object> UpdateCuenta(Cuenta cuenta)
        {
            return UpdateCityApp.Save(cuenta);
        }
    }
}
