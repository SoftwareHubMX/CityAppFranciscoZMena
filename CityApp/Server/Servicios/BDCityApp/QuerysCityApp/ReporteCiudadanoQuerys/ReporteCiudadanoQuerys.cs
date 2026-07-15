using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys
{
    public class ReporteCiudadanoQuerys
    {
        private ReporteCiudadanoInsert ReporteCiudadanoInsert;
        private IdReporteCiudadanoSelect IdReporteCiudadanoSelect;
        private ReportesCiudadanosSelect ReportesCiudadanosSelect;
        private ReporteCiudadanoSelect ReporteCiudadanoSelect;
        private ReporteCiudadanoUpdate ReporteCiudadanoUpdate;

        public ReporteCiudadanoQuerys(CityAppContext cityAppContex)
        {
            ReporteCiudadanoInsert = new ReporteCiudadanoInsert(cityAppContex);
            IdReporteCiudadanoSelect = new IdReporteCiudadanoSelect(cityAppContex);
            ReportesCiudadanosSelect = new ReportesCiudadanosSelect(cityAppContex);
            ReporteCiudadanoUpdate = new ReporteCiudadanoUpdate(cityAppContex);
            ReporteCiudadanoSelect = new ReporteCiudadanoSelect(cityAppContex);
        }

        //insert
        public Response<object> InsertReporteCiudadano(ReporteCiudadano reporteCiudadano)
        {
            return ReporteCiudadanoInsert.InsertReporteCiudadano(reporteCiudadano);
        }

        //select
        public Response<int> SelectIdReporteCiudadanoReporteCiudadanoCordenadasEstatus(ReporteCiudadano reporteCiudadano)
        {
            return IdReporteCiudadanoSelect.SelectIdReporteCiudadanoReporteCiudadanoCordenadasEstatus(reporteCiudadano);
        }
        public Response<IEnumerable<ReporteCiudadano>> SelectReportesCiudadanosIdCuentaFiltros(int idCuenta, FiltroReportesCiudadanos filtroReportesCiudadanos)
        {
            return ReportesCiudadanosSelect.SelectReportesCiudadanosIdCuentaFiltros(idCuenta, filtroReportesCiudadanos);
        }
        public Response<IEnumerable<ReporteCiudadano>> SelectReportesCiudadanosFiltros(FiltroReportesCiudadanos filtroReportesCiudadanos)
        {
            return ReportesCiudadanosSelect.SelectReportesCiudadanosFiltros(filtroReportesCiudadanos);
        }
        public Response<ReporteCiudadano> SelectReporteCiudadanoIdReporteCiudadano(int idReporteCiudadano)
        {
            return ReporteCiudadanoSelect.SelectReporteCiudadanoIdReporteCiudadano(idReporteCiudadano);
        }
        public Response<ReporteCiudadano> SelectReporteCiudadanoCompletoIdReporteCiudadano(int idReporteCiudadano)
        {
            return ReporteCiudadanoSelect.SelectReporteCiudadanoCompletoIdReporteCiudadano(idReporteCiudadano);
        }

        public Response<IEnumerable<ReporteCiudadano>> SelectReportesCiudadanosEstatusReporteCiudadano(int idEstausReporteCiudadano, FechasDashBoard fechasDashBoard)
        {
            return ReportesCiudadanosSelect.SelectReportesCiudadanosEstatusReporteCiudadano(idEstausReporteCiudadano, fechasDashBoard);
        }
        public Response<IEnumerable<ReporteCiudadano>> SelectReportesCiudadanosEstatusReporteCiudadanoDash(int idEstausReporteCiudadano, FechasDashBoard fechasDashBoard)
        {
            return ReportesCiudadanosSelect.SelectReportesCiudadanosEstatusReporteCiudadanoDash(idEstausReporteCiudadano, fechasDashBoard);
        }
        //update
        public Response<object> UpdateReporteCiudadano(ReporteCiudadano reporteCiudadano)
        {
            return ReporteCiudadanoUpdate.UpdateReporteCiudadano(reporteCiudadano);
        }
    }
}
