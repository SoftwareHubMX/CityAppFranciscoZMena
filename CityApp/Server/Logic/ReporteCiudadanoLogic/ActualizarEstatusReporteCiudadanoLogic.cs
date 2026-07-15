using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ReporteCiudadanoLogic
{
    public class ActualizarEstatusReporteCiudadanoLogic
    {
        private ReporteCiudadanoQuerys ReporteCiudadanoQuerys;

        private int IdReporteCiudadano;
        private int IdEstatusReporteCiudadano;

        public ActualizarEstatusReporteCiudadanoLogic(CityAppContext cityAppContext, int idReporteCiudadano, int idEstatusReporteCiudadano)
        {
            ReporteCiudadanoQuerys = new ReporteCiudadanoQuerys(cityAppContext);

            IdReporteCiudadano = idReporteCiudadano;
            IdEstatusReporteCiudadano= idEstatusReporteCiudadano;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            Response<ReporteCiudadano> responseReporteCiudadano = ReporteCiudadanoQuerys.SelectReporteCiudadanoIdReporteCiudadano(IdReporteCiudadano);
            response.Status = responseReporteCiudadano.Status;
            if (response.Status.Exito == 1)
            {
                responseReporteCiudadano.Data.IdEstatusReporteCiudadano = IdEstatusReporteCiudadano;
                response = ReporteCiudadanoQuerys.UpdateReporteCiudadano(responseReporteCiudadano.Data);
            }

            return response;
        }
    }
}
