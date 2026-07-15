using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoSolicitudQuerys.Select
{
    public class TipoSolicitudSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoSolicitud> SelectCityApp = new SelectCityApp<TipoSolicitud>();

        public TipoSolicitudSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TipoSolicitud> SelectTipoSolicitudIdTipoSolicitud(int idTipoSolicitud)
        {
            Response<TipoSolicitud> response = new Response<TipoSolicitud>();

            try
            {
                response.Data = (from data in CityAppContext.TiposSolicitud
                                 orderby data.IdTipoSolicitud
                                 where data.IdTipoSolicitud == idTipoSolicitud
                                 select new TipoSolicitud()
                                 {
                                     IdTipoSolicitud = data.IdTipoSolicitud,
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
