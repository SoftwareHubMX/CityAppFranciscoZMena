using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ReporteCiudadanoLogic
{
    public class ActualizacionObservacionesReporteCiudadanoLogic
    {
        private ReporteCiudadanoQuerys ReporteCiudadanoQuerys;

        private int IdReporteCiudadano;
        private string Observaciones;

        public ActualizacionObservacionesReporteCiudadanoLogic(CityAppContext cityAppContext, int idReporteCiudadano, string observaciones)
        {
            ReporteCiudadanoQuerys = new ReporteCiudadanoQuerys(cityAppContext);

            IdReporteCiudadano = idReporteCiudadano;
            Observaciones = observaciones;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            Response<ReporteCiudadano> responseReporteCiudadano = ReporteCiudadanoQuerys.SelectReporteCiudadanoIdReporteCiudadano(IdReporteCiudadano);
            response.Status = responseReporteCiudadano.Status;
            if (response.Status.Exito == 1)
            {
                responseReporteCiudadano.Data.Observaciones = Observaciones;
                response = ReporteCiudadanoQuerys.UpdateReporteCiudadano(responseReporteCiudadano.Data);
            }

            return response;
        }
    }
}
