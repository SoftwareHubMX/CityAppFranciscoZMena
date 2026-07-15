using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoJustificacionSolicitudQuerys.Select
{
    public class TiposJustificacionSolicitudSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoJustificacionSolicitud> SelectCityApp = new SelectCityApp<TipoJustificacionSolicitud>();

        public TiposJustificacionSolicitudSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoJustificacionSolicitud>> SelectTiposJustificacionSolicitud()
        {
            Response<IEnumerable<TipoJustificacionSolicitud>> response = new Response<IEnumerable<TipoJustificacionSolicitud>>();

            try
            {
                response.Data = CityAppContext.TiposJustificacionSolicitud;

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
