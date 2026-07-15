using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSolicitudQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.TipoSolicitudLogic
{
    public class ConsultarTiposSolicitudLogic
    {
        private TipoSolicitudQuerys TipoSolicitudQuerys;

        public ConsultarTiposSolicitudLogic(CityAppContext cityAppContext)
        {
            TipoSolicitudQuerys = new TipoSolicitudQuerys(cityAppContext);
        }

        public Response<List<TipoSolicitud>> Consultar()
        {
            Response<List<TipoSolicitud>> response = new Response<List<TipoSolicitud>>();

            Response<IEnumerable<TipoSolicitud>> responseTipoSolicitud = TipoSolicitudQuerys.SelectTiposSolicitud();
            response.Status = responseTipoSolicitud.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseTipoSolicitud.Data.ToList();
            }
            return response;
        }
    }
}
