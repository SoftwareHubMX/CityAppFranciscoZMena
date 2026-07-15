using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSolicitudQuerys.Select
{
    public class TiposSolicitudSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoSolicitud> SelectCityApp = new SelectCityApp<TipoSolicitud>();

        public TiposSolicitudSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoSolicitud>> SelectTiposSolicitud()
        {
            Response<IEnumerable<TipoSolicitud>> response = new Response<IEnumerable<TipoSolicitud>>();

            try
            {
                response.Data = CityAppContext.TiposSolicitud;

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
