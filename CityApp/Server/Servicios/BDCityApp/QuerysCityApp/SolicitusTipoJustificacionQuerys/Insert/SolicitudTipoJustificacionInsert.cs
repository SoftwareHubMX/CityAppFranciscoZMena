using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys.Insert
{
    public class SolicitudTipoJustificacionInsert
    {
        private InsertCityApp<SolicitudTipoJustificacion> InsertCityApp;

        public SolicitudTipoJustificacionInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<SolicitudTipoJustificacion>(cityAppContext);
        }

        public Response<object> InsertSolicitudTipoJustificacion(SolicitudTipoJustificacion solicitudTipoJustificacion)
        {
            return InsertCityApp.Save(solicitudTipoJustificacion);
        }
    }
}
