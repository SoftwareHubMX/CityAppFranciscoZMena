using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Migrations;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CuentaLogic
{
    public class ActualizarEstatusActivoLogic
    {
        private CuentaQuerys CuentaQuerys;

        private int IdCuenta;
        private bool EstatusActivo;

        public ActualizarEstatusActivoLogic(CityAppContext cityAppContext, int idCuenta, bool estatusActivo)
        {
            CuentaQuerys = new CuentaQuerys(cityAppContext);

            IdCuenta = idCuenta;
            EstatusActivo = estatusActivo;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            Response<Cuenta> responseCuenta = CuentaQuerys.SelectCuentaIdCuenta(IdCuenta);
            response.Status = responseCuenta.Status;
            if (response.Status.Exito == 1)
            {
                responseCuenta.Data.EstatusActivo = EstatusActivo;
                response = CuentaQuerys.UpdateCuenta(responseCuenta.Data);
            }

            return response;
        }
    }
}
