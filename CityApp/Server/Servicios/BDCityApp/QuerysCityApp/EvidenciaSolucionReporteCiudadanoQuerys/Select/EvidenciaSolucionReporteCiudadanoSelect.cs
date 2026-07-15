using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys.Select
{
    public class EvidenciaSolucionReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<EvidenciaSolucionReporteCiudadano> SelectCityApp = new SelectCityApp<EvidenciaSolucionReporteCiudadano>();

        public EvidenciaSolucionReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<EvidenciaSolucionReporteCiudadano> SelectEvidenciaSolucionReporteCiudadanoIdEvidenciaSolucionReporteCiudadano(int idEnvidenciaSolucionReporteCiudadano)
        {
            Response<EvidenciaSolucionReporteCiudadano> response = new Response<EvidenciaSolucionReporteCiudadano>();

            try
            {
                response.Data = CityAppContext.EvidenciasSolucionReporteCiudadano.Where(d => d.IdEnvidenciaSolucionReporteCiudadano == idEnvidenciaSolucionReporteCiudadano).First();

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
