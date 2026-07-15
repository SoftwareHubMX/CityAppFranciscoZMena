using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys.Select
{
    public class IdReporteCiudadanoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdReporteCiudadanoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<int> SelectIdReporteCiudadanoReporteCiudadanoCordenadasEstatus(ReporteCiudadano reporteCiudadano)
        {
            Response<int> response = new Response<int>();

            try
            {
                double latitudInferior = reporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.Latitud - 0.0005;
                double latitudSuperior = reporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.Latitud + 0.0005;
                double loingitudInferior = reporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.Longitud - 0.0005;
                double loingitudSuperior = reporteCiudadano.VercionesReporteCiudadano[0].DireccionReporteCiudadano.Longitud + 0.0005;

                response.Data = (from data in CityAppContext.VercionesReporteCiudadano
                                 orderby data.FechaReporte
                                 where data.ReporteCiudadano.IdTipoReporteCiudadano == reporteCiudadano.IdTipoReporteCiudadano
                                 && data.ReporteCiudadano.IdEstatusReporteCiudadano != 3
                                 && data.ReporteCiudadano.IdEstatusReporteCiudadano != 4
                                 && data.DireccionReporteCiudadano.Latitud >= latitudInferior
                                 && data.DireccionReporteCiudadano.Latitud <= latitudSuperior
                                 && data.DireccionReporteCiudadano.Longitud >= loingitudInferior
                                 && data.DireccionReporteCiudadano.Longitud <= loingitudSuperior
                                 select data.IdReporteCiudadano).Last();

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
