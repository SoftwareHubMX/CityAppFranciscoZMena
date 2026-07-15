using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoReporteCiudadanoQuerys.Select
{
    public class TiposReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoReporteCiudadano> SelectCityApp = new SelectCityApp<TipoReporteCiudadano>();

        public TiposReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoReporteCiudadano>> SelectTiposReporteCiudadano()
        {
            Response<IEnumerable<TipoReporteCiudadano>> response = new Response<IEnumerable<TipoReporteCiudadano>>();

            try
            {
                response.Data = CityAppContext.TiposReporteCiudadano;

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
