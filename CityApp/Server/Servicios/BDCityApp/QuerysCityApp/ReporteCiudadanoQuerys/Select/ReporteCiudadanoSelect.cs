using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys.Select
{
    public class ReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ReporteCiudadano> SelectCityApp = new SelectCityApp<ReporteCiudadano>();

        public ReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<ReporteCiudadano> SelectReporteCiudadanoIdReporteCiudadano(int idReporteCiudadano)
        {
            Response<ReporteCiudadano> response = new Response<ReporteCiudadano>();

            try
            {
                response.Data = CityAppContext.ReportesCiudadanos.Where(d => d.IdReporteCiudadano == idReporteCiudadano).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<ReporteCiudadano> SelectReporteCiudadanoCompletoIdReporteCiudadano(int idReporteCiudadano)
        {
            Response<ReporteCiudadano> response = new Response<ReporteCiudadano>();

            try
            {
                response.Data = (from data in CityAppContext.ReportesCiudadanos
                                orderby data.IdReporteCiudadano
                                where data.IdReporteCiudadano == idReporteCiudadano
                                select new ReporteCiudadano()
                                {
                                    IdReporteCiudadano = data.IdReporteCiudadano,
                                    IdTipoReporteCiudadano = data.IdTipoReporteCiudadano,
                                    IdEstatusReporteCiudadano = data.IdEstatusReporteCiudadano,
                                    TipoReporteCiudadano = data.TipoReporteCiudadano,
                                    Observaciones = data.Observaciones,  
                                    EstatusReporteCiudadano = data.EstatusReporteCiudadano,
                                    EvidenciasSolucionReporteCiudadano = data.EvidenciasSolucionReporteCiudadano,
                                    VercionesReporteCiudadano = data.VercionesReporteCiudadano,
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
