using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SolicitudTipoJustificacionLogic
{
    public class ConsultarSolicitudesTipoJustificacionLogic
    {
        private SolicitusTipoJustificacionQuerys SolicitusTipoJustificacionQuerys;
        private int IdSolicitudPoda;
        private int IdTipoJustificacionSolicitud;

        public ConsultarSolicitudesTipoJustificacionLogic(CityAppContext cityAppContex, int idSolicitudPoda, int idTipoJustificacionSolicitud)
        {
            SolicitusTipoJustificacionQuerys = new SolicitusTipoJustificacionQuerys(cityAppContex);
            IdSolicitudPoda = idSolicitudPoda;
            IdTipoJustificacionSolicitud = idTipoJustificacionSolicitud;
        }

        public Response<SolicitudTipoJustificacion> Consultar()
        {
            return SolicitusTipoJustificacionQuerys.SelectSolicitudTipoJustificacionIdSolicitudIdTipoJustificacion(IdSolicitudPoda, IdTipoJustificacionSolicitud);
        }
    }
}
