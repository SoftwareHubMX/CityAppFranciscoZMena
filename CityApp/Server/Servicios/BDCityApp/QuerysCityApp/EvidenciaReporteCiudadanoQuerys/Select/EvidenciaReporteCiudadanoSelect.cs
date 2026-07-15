using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys.Select
{
    public class EvidenciaReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<EvidenciaReporteCiudadano> SelectCityApp = new SelectCityApp<EvidenciaReporteCiudadano>();

        public EvidenciaReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<EvidenciaReporteCiudadano> SelectEvidenciaReporteCiudadanoIdEnvidenciaReporteCiudadano(int idEnvidenciaReporteCiudadano)
        {
            Response<EvidenciaReporteCiudadano> response = new Response<EvidenciaReporteCiudadano>();

            try
            {
                response.Data = CityAppContext.EvidenciasReporteCiudadano.Where(d => d.IdEnvidenciaReporteCiudadano == idEnvidenciaReporteCiudadano).First();

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
