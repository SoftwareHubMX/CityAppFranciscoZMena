using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoJustificacionSolicitudQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoJustificacionSolicitudLogic
{
    public class ConsultarTiposJustificacionSolicitudLogic
    {
        private TipoJustificacionSolicitudQuerys TipoJustificacionSolicitudQuerys;

        public ConsultarTiposJustificacionSolicitudLogic(CityAppContext cityAppContext)
        {
            TipoJustificacionSolicitudQuerys = new TipoJustificacionSolicitudQuerys(cityAppContext);
        }

        public Response<List<TipoJustificacionSolicitud>> Consultar()
        {
            Response<List<TipoJustificacionSolicitud>> response = new Response<List<TipoJustificacionSolicitud>>();

            Response<IEnumerable<TipoJustificacionSolicitud>> responseTipoJustificacion = TipoJustificacionSolicitudQuerys.SelectTiposJustificacionSolicitud();
            response.Status = responseTipoJustificacion.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseTipoJustificacion.Data.ToList();
            }
            return response;
        }
    }
}
