using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SolicitudTipoJustificacionLogic
{
    public class CrearSolicitudTipoJustificacionLogic
    {
        private SolicitusTipoJustificacionQuerys SolicitusTipoJustificacionQuerys;

        private SolicitudTipoJustificacion SolicitudTipoJustificacion;

        public CrearSolicitudTipoJustificacionLogic(CityAppContext cityAppContext, SolicitudTipoJustificacion solicitudTipoJustificacion)
        {
            SolicitusTipoJustificacionQuerys = new SolicitusTipoJustificacionQuerys(cityAppContext);

            SolicitudTipoJustificacion = solicitudTipoJustificacion;
            SolicitudTipoJustificacion.TiposJustificacionSolicitud = null;
        }

        public Response<object> Crear()
        {
            return SolicitusTipoJustificacionQuerys.InsertSolicitudTipoJustificacion(SolicitudTipoJustificacion);
        }
    }
}
