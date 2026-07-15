using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys.Select
{
    public class SolicitudTipoJustificacionSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<SolicitudTipoJustificacion> SelectCityApp = new SelectCityApp<SolicitudTipoJustificacion>();

        public SolicitudTipoJustificacionSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<SolicitudTipoJustificacion> SelectSolicitudTipoJustificacionIdSolicitudIdTipoJustificacion(int idTipoJustificacionSolicitud, int idSolicitudPoda)
        {
            Response<SolicitudTipoJustificacion> response = new Response<SolicitudTipoJustificacion>();

            try
            {
                response.Data = CityAppContext.SolicitudesTipoJustificaciones.Where(d => d.IdTipoJustificacionSolicitud == idTipoJustificacionSolicitud && d.IdSolicitudPoda == idSolicitudPoda).LastOrDefault();


                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
