using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusReporteCiudadanoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusReporteCiudadanoQuerys
{
    public class EstatusReporteCiudadanoQuerys
    {
        private EstatusReporteCiudadanoSelect EstatusReporteCiudadanoSelect;

        public EstatusReporteCiudadanoQuerys(CityAppContext cityAppContext)
        {
            EstatusReporteCiudadanoSelect = new EstatusReporteCiudadanoSelect(cityAppContext);
        }

        //select
        public Response<IEnumerable<EstatusReporteCiudadano>> SelectEstatusReporteCiudadano()
        {
            return EstatusReporteCiudadanoSelect.SelectEstatusReporteCiudadano();
        }
    }
}
