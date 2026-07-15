using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusCuentaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusCuentaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusCuentaQuerys
{
    public class EstatusCuentaQuerys
    {
        private EstatusCuentaSelect EstatusCuentaSelect;
        private EstatusCuentaUpdate EstatusCuentaUpdate;

        public EstatusCuentaQuerys(CityAppContext cityAppContext)
        {
            EstatusCuentaSelect = new EstatusCuentaSelect(cityAppContext);
            EstatusCuentaUpdate = new EstatusCuentaUpdate(cityAppContext);
        }

        //select
        public Response<EstatusCuenta> SelectEstatusCuentaIdCuenta(int idCuenta)
        {
            return EstatusCuentaSelect.SelectEstatusCuentaIdCuenta(idCuenta);
        }

        //update
        public Response<object> UpdateEstatusCuenta(EstatusCuenta estatusCuenta)
        {
            return EstatusCuentaUpdate.UpdateEstatusCuenta(estatusCuenta);
        }
    }
}
