using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys
{
    public class SolicitusTipoJustificacionQuerys
    {
        private SolicitudTipoJustificacionDelete SolicitudTipoJustificacionDelete;
        private SolicitudTipoJustificacionInsert SolicitudTipoJustificacionInsert;
        private SolicitudTipoJustificacionSelect SolicitudTipoJustificacionSelect;
        private SolicitudesTipoJustificacionSelect SolicitudesTipoJustificacionSelect;

        public SolicitusTipoJustificacionQuerys(CityAppContext cityAppContext)
        {
            SolicitudTipoJustificacionDelete = new SolicitudTipoJustificacionDelete(cityAppContext);
            SolicitudTipoJustificacionInsert = new SolicitudTipoJustificacionInsert(cityAppContext);
            SolicitudTipoJustificacionSelect = new SolicitudTipoJustificacionSelect(cityAppContext);
            SolicitudesTipoJustificacionSelect = new SolicitudesTipoJustificacionSelect(cityAppContext);

        }
        //Delete
        public Response<object> DeleteSolicitudTipoJustificacion(SolicitudTipoJustificacion solicitudTipoJustificacion)
        {
            return SolicitudTipoJustificacionDelete.DeleteSolicitudTipoJustificacion(solicitudTipoJustificacion);
        }

        //Insert
        public Response<object> InsertSolicitudTipoJustificacion(SolicitudTipoJustificacion solicitudTipoJustificacion)
        {
            return SolicitudTipoJustificacionInsert.InsertSolicitudTipoJustificacion(solicitudTipoJustificacion);
        }

        //Select
        public Response<SolicitudTipoJustificacion> SelectSolicitudTipoJustificacionIdSolicitudIdTipoJustificacion(int idTipoJustificacionSolicitud, int idSolicitud)
        {
            return SolicitudTipoJustificacionSelect.SelectSolicitudTipoJustificacionIdSolicitudIdTipoJustificacion(idTipoJustificacionSolicitud, idSolicitud);
        }
        public Response<IEnumerable<SolicitudTipoJustificacion>> SelectSolicitudTipoJustificacion(int idSolicitud)
        {
            return SolicitudesTipoJustificacionSelect.SelectSolicitudTipoJustificacion(idSolicitud);
        }
    }
}
