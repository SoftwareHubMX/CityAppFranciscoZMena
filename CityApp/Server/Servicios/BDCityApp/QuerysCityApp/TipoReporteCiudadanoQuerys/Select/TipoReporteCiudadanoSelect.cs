using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoReporteCiudadanoQuerys.Select
{
    public class TipoReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoReporteCiudadano> SelectCityApp = new SelectCityApp<TipoReporteCiudadano>();

        public TipoReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TipoReporteCiudadano> SelectTipoReporteCiudadanoIdTipo(int idTipo)
        {
            Response<TipoReporteCiudadano> response = new Response<TipoReporteCiudadano>();

            try
            {
                response.Data = (from data in CityAppContext.TiposReporteCiudadano
                                orderby data.IdTipoReporteCiudadano
                                where data.IdTipoReporteCiudadano == idTipo
                                select new TipoReporteCiudadano()
                                {
                                    IdTipoReporteCiudadano = data.IdTipoReporteCiudadano,
                                    TipoReporte = data.TipoReporte,
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
