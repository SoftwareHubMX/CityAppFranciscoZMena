using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys.Delete
{
    public class SolicitudTipoJustificacionDelete
    {
        private DeleteCityApp<SolicitudTipoJustificacion> DeleteCityApp;

        public SolicitudTipoJustificacionDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<SolicitudTipoJustificacion>(cityAppContext);
        }

        public Response<object> DeleteSolicitudTipoJustificacion(SolicitudTipoJustificacion solicitudTipoJustificacion)
        {
            return DeleteCityApp.Save(solicitudTipoJustificacion);
        }
    }
}
