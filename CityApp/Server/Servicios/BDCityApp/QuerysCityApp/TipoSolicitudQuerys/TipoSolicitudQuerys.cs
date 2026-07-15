using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSolicitudQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSolicitudQuerys
{
    public class TipoSolicitudQuerys
    {
        private TiposSolicitudSelect TiposSolicitudSelect;
        private TipoSolicitudSelect TipoSolicitudSelect;

        public TipoSolicitudQuerys(CityAppContext cityAppContex)
        {
            TiposSolicitudSelect = new TiposSolicitudSelect(cityAppContex);
            TipoSolicitudSelect = new TipoSolicitudSelect(cityAppContex);
        }

        //select
        public Response<IEnumerable<TipoSolicitud>> SelectTiposSolicitud()
        {
            return TiposSolicitudSelect.SelectTiposSolicitud();
        }
        public Response<TipoSolicitud> SelectTipoSolicitudIdTipoSolicitud(int idTipoSolicitud)
        {
            return TipoSolicitudSelect.SelectTipoSolicitudIdTipoSolicitud(idTipoSolicitud);
        }
    }
}
