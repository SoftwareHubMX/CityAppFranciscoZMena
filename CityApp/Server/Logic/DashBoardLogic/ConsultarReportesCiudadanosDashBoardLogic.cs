using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusReporteCiudadanoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DashBoardLogic
{
    public class ConsultarReportesCiudadanosDashBoardLogic
    {
        private EstatusReporteCiudadanoQuerys EstatusReporteCiudadanoQuerys;
        private ReporteCiudadanoQuerys ReporteCiudadanoQuerys;
        private FechasDashBoard FechasDashBoard;

        public ConsultarReportesCiudadanosDashBoardLogic(CityAppContext cityAppContext, FechasDashBoard fechasDashBoard)
        {
            EstatusReporteCiudadanoQuerys = new EstatusReporteCiudadanoQuerys(cityAppContext);
            ReporteCiudadanoQuerys = new ReporteCiudadanoQuerys(cityAppContext);
            FechasDashBoard = fechasDashBoard;
        }

        public Response<List<ChartData>> Consultar()
        {
            Response<List<ChartData>> response = new Response<List<ChartData>>();


            Response<IEnumerable<EstatusReporteCiudadano>> responseEstatussReporteCiudadano = EstatusReporteCiudadanoQuerys.SelectEstatusReporteCiudadano();
            response.Status = responseEstatussReporteCiudadano.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<ChartData>();
                foreach (var Estatus in responseEstatussReporteCiudadano.Data)
                {
                    ChartData data = new ChartData()
                    {
                        Label = Estatus.Estatus,
                        Data = new List<double>()
                    };
                    Response<IEnumerable<ReporteCiudadano>> responseReporteCiudadano = new Response<IEnumerable<ReporteCiudadano>>();
                    responseReporteCiudadano = ReporteCiudadanoQuerys.SelectReportesCiudadanosEstatusReporteCiudadanoDash(Estatus.IdEstatusReporteCiudadano, FechasDashBoard);
                    response.Status = responseReporteCiudadano.Status;
                    if (response.Status.Exito == 1)
                    {
                        data.Data.Add(responseReporteCiudadano.Data.ToList().Count);

                    }
                    else
                    {
                        data.Data.Add(0);
                    }
                    response.Data.Add(data);
                }
            }

            response.Status.Exito = (response.Data.Count > 0) ? 1 : 0;
            response.Status.Mensaje = (response.Data.Count > 0) ? "OK" : "Error al generar el DataSet";

            return response;
        }
    }
}
