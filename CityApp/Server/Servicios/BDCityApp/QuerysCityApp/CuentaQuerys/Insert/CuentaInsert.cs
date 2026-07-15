using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Insert
{
    public class CuentaInsert
    {
        private InsertCityApp<Cuenta> InsertCityApp;

        public CuentaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Cuenta>(cityAppContext);
        }

        public Response<object> InsertCuenta(Cuenta cuenta)
        {
            return InsertCityApp.Save(cuenta);
        }
    }
}
