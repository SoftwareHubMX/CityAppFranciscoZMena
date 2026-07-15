using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoReporteCiudadanoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoReporteCiudadanoQuerys
{
    public class TipoReporteCiudadanoQuerys
    {
        private TiposReporteCiudadanoSelect TiposReporteCiudadanoSelect;
        private TipoReporteCiudadanoSelect TipoReporteCiudadanoSelect;

        public TipoReporteCiudadanoQuerys(CityAppContext cityAppContex)
        {
            TiposReporteCiudadanoSelect = new TiposReporteCiudadanoSelect(cityAppContex);
            TipoReporteCiudadanoSelect = new TipoReporteCiudadanoSelect(cityAppContex);
        }

        //select
        public Response<IEnumerable<TipoReporteCiudadano>> SelectTiposReporteCiudadano()
        {
            return TiposReporteCiudadanoSelect.SelectTiposReporteCiudadano();
        }
        public Response<TipoReporteCiudadano> SelectTipoReporteCiudadanoIdTipo(int idTipo)
        {
            return TipoReporteCiudadanoSelect.SelectTipoReporteCiudadanoIdTipo(idTipo);
        }
    }
}
