using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitusTipoJustificacionQuerys.Select
{
    public class SolicitudesTipoJustificacionSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<SolicitudTipoJustificacion> SelectCityApp = new SelectCityApp<SolicitudTipoJustificacion>();
        private Paginado<SolicitudTipoJustificacion> Paginado = new Paginado<SolicitudTipoJustificacion>();

        public SolicitudesTipoJustificacionSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<SolicitudTipoJustificacion>> SelectSolicitudTipoJustificacion(int idSolicitudPoda)
        {
            Response<IEnumerable<SolicitudTipoJustificacion>> response = new Response<IEnumerable<SolicitudTipoJustificacion>>();

            try
            {
                response.Data = CityAppContext.SolicitudesTipoJustificaciones.Where(d => d.IdSolicitudPoda == idSolicitudPoda);

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
