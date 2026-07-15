using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoJustificacionSolicitudQuerys.Select
{
    public class TipoJustificacionSolicitudSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoJustificacionSolicitud> SelectCityApp = new SelectCityApp<TipoJustificacionSolicitud>();

        public TipoJustificacionSolicitudSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TipoJustificacionSolicitud> SelectTipoJustificacionSolicitudIdTipoJustificacion(int idTipoJustificacionSolicitud)
        {
            Response<TipoJustificacionSolicitud> response = new Response<TipoJustificacionSolicitud>();

            try
            {
                response.Data = (from data in CityAppContext.TiposJustificacionSolicitud
                                 orderby data.IdTipoJustificacionSolicitud
                                 where data.IdTipoJustificacionSolicitud == idTipoJustificacionSolicitud
                                 select new TipoJustificacionSolicitud()
                                 {
                                     IdTipoJustificacionSolicitud = data.IdTipoJustificacionSolicitud,
                                     Tipo = data.Tipo,
                                 }).FirstOrDefault();

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
