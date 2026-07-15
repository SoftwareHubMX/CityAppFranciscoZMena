using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoJustificacionSolicitudQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoJustificacionSolicitudLogic
{
    public class ConsultarTipoJustificacuinSolicitudLogic
    {
        private TipoJustificacionSolicitudQuerys TipoJustificacionSolicitudQuerys;


        private int IdTipoJudtificacionSolicitud;
        private TipoJustificacionSolicitud TipoJustificacionSolicitud;

        public ConsultarTipoJustificacuinSolicitudLogic(CityAppContext cityAppContetx, int idTipoJustificacionSolicitud)
        {
            TipoJustificacionSolicitudQuerys = new TipoJustificacionSolicitudQuerys(cityAppContetx);

            IdTipoJudtificacionSolicitud = idTipoJustificacionSolicitud;
        }

        public Response<TipoJustificacionSolicitud> Consultar()
        {
            return TipoJustificacionSolicitudQuerys.SelectTipoJustificacionSolicitudIdTipoJustificacion(IdTipoJudtificacionSolicitud);
        }
    }
}
