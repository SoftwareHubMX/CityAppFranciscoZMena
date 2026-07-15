using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoJustificacionSolicitudQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoJustificacionSolicitudQuerys
{
    public class TipoJustificacionSolicitudQuerys
    {
        private TiposJustificacionSolicitudSelect TiposJustificacionSolicitudSelect;
        private TipoJustificacionSolicitudSelect TipoJustificacionSolicitudSelect;

        public TipoJustificacionSolicitudQuerys(CityAppContext cityAppContex)
        {
            TiposJustificacionSolicitudSelect = new TiposJustificacionSolicitudSelect(cityAppContex);
            TipoJustificacionSolicitudSelect = new TipoJustificacionSolicitudSelect(cityAppContex);
        }

        //select
        public Response<IEnumerable<TipoJustificacionSolicitud>> SelectTiposJustificacionSolicitud()
        {
            return TiposJustificacionSolicitudSelect.SelectTiposJustificacionSolicitud();
        }
        public Response<TipoJustificacionSolicitud> SelectTipoJustificacionSolicitudIdTipoJustificacion(int idTipoJustificacionSolicitud)
        {
            return TipoJustificacionSolicitudSelect.SelectTipoJustificacionSolicitudIdTipoJustificacion(idTipoJustificacionSolicitud);
        }
    }
}
