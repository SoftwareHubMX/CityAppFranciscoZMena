using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusReporteCiudadanoQuerys.Select
{
    public class EstatusReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<EstatusReporteCiudadano> SelectCityApp = new SelectCityApp<EstatusReporteCiudadano>();

        public EstatusReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<EstatusReporteCiudadano>> SelectEstatusReporteCiudadano()
        {
            Response<IEnumerable<EstatusReporteCiudadano>> response = new Response<IEnumerable<EstatusReporteCiudadano>>();

            try
            {
                response.Data = CityAppContext.EstatusReporteCiudadano;

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
