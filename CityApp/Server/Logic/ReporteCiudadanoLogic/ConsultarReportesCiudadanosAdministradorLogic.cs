using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.VercionReporteCiudadanoQuerys;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ReporteCiudadanoLogic
{
    public class ConsultarReportesCiudadanosAdministradorLogic
    {
        private ReporteCiudadanoQuerys ReporteCiudadanoQuerys;
        private VercionReporteCiudadanoQuerys VercionReporteCiudadanoQuerys;
        private EvidenciaReporteCiudadanoQuerys EvidenciaReporteCiudadanoQuerys;
        private EvidenciaSolucionReporteCiudadanoQuerys EvidenciaSolucionReporteCiudadanoQuerys;
        private TipoReporteCiudadanoQuerys TipoReporteCiudadanoQuerys;
        private CuentaQuerys CuentaQuerys;

        private Paginado<ReporteCiudadano> Paginado = new Paginado<ReporteCiudadano>();

        private FiltroReportesCiudadanos FiltroReportesCiudadanos;
        private List<ReporteCiudadano> ReportesCiudadanos;

        public ConsultarReportesCiudadanosAdministradorLogic(CityAppContext cityAppContex, FiltroReportesCiudadanos filtroReportesCiudadanos)
        {
            ReporteCiudadanoQuerys = new ReporteCiudadanoQuerys(cityAppContex);
            EvidenciaReporteCiudadanoQuerys = new EvidenciaReporteCiudadanoQuerys(cityAppContex);
            EvidenciaSolucionReporteCiudadanoQuerys = new EvidenciaSolucionReporteCiudadanoQuerys(cityAppContex);
            VercionReporteCiudadanoQuerys = new VercionReporteCiudadanoQuerys(cityAppContex);
            TipoReporteCiudadanoQuerys = new TipoReporteCiudadanoQuerys(cityAppContex);
            CuentaQuerys = new CuentaQuerys(cityAppContex);

            FiltroReportesCiudadanos = filtroReportesCiudadanos;
        }

        public Response<List<ReporteCiudadano>> Consultar()
        {
            Response<List<ReporteCiudadano>> response = new Response<List<ReporteCiudadano>>();

            Response<IEnumerable<ReporteCiudadano>> responseReportesCiudadanos = ReporteCiudadanoQuerys.SelectReportesCiudadanosFiltros(FiltroReportesCiudadanos);
            response.Status = responseReportesCiudadanos.Status;
            if (response.Status.Exito == 1)
            {
                ReportesCiudadanos = responseReportesCiudadanos.Data.ToList();
                Response<object> responseCargarListas = CargarListas();
                response.Status = responseCargarListas.Status;
                if (response.Status.Exito == 1)
                {
                    Response<object> responseOrdenarPaginar = OrdenarPaginar();
                    response.Status = responseOrdenarPaginar.Status;
                    if (response.Status.Exito == 1)
                    {
                        response.Data = ReportesCiudadanos;
                        response.Info = responseOrdenarPaginar.Info;
                    }
                }
            }

            return response;
        }

        private Response<object> CargarListas()
        {
            Response<object> response = new Response<object>();

            for (int i = 0; i < ReportesCiudadanos.Count; i++)
            {
                response = CargarTipoReporte(i);
                if (response.Status.Exito == 1)
                {
                    response = CargarVercionReporteCiudadano(i);
                    if (response.Status.Exito == 1)
                    {
                        response = CargarEvidenciasSolucion(i);
                    }
                    else
                    {
                        i = ReportesCiudadanos.Count;
                    }
                }
            }

            return response;
        }

        private Response<object> CargarVercionReporteCiudadano(int i)
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<VercionReporteCiudadano>> responseVercionesReporteCiudadano = VercionReporteCiudadanoQuerys.SelectVercionesReporteCiudadanoIdReporteCiudadano(ReportesCiudadanos[i].IdReporteCiudadano);
            response.Status = responseVercionesReporteCiudadano.Status;
            if (response.Status.Exito == 1)
            {
                ReportesCiudadanos[i].VercionesReporteCiudadano = responseVercionesReporteCiudadano.Data.ToList();
                response = CargarEvidenciaReporteCiudadano(i);
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }

        private Response<object> CargarEvidenciaReporteCiudadano(int i)
        {
            Response<object> response = new Response<object>();

            for (int j = 0; j < ReportesCiudadanos[i].VercionesReporteCiudadano.Count; j++)
            {
                Response<IEnumerable<EvidenciaReporteCiudadano>> responseEvidenciasReporteCiudadano = EvidenciaReporteCiudadanoQuerys.SelectEvidenciasReporteCiudadanoIdVercionReporteCiudadano(ReportesCiudadanos[i].VercionesReporteCiudadano[j].IdVercionReporteCiudadano);
                response.Status = responseEvidenciasReporteCiudadano.Status;
                if (response.Status.Exito == 1)
                {
                    ReportesCiudadanos[i].VercionesReporteCiudadano[j].EvidenciasReporteCiudadano = responseEvidenciasReporteCiudadano.Data.ToList();
                }
                else if (response.Status.Exito == 2)
                {
                    response.Status.Exito = 1;
                }
            }

            return response;
        }

        private Response<object> CargarEvidenciasSolucion(int i)
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<EvidenciaSolucionReporteCiudadano>> responseEvidenciasSolucionReporteCiudadano = EvidenciaSolucionReporteCiudadanoQuerys.SelectEvidenciasSolucionReporteCiudadanoIdReporteCiudadano(ReportesCiudadanos[i].IdReporteCiudadano);
            response.Status = responseEvidenciasSolucionReporteCiudadano.Status;
            if (response.Status.Exito == 1 && responseEvidenciasSolucionReporteCiudadano.Data.Count() > 0)
            {
                ReportesCiudadanos[i].EvidenciasSolucionReporteCiudadano = responseEvidenciasSolucionReporteCiudadano.Data.ToList();
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }

        private Response<object> CargarTipoReporte(int i)
        {
            Response<object> response = new Response<object>();

            Response<TipoReporteCiudadano> responseTipoReporte = TipoReporteCiudadanoQuerys.SelectTipoReporteCiudadanoIdTipo(ReportesCiudadanos[i].IdTipoReporteCiudadano);
            response.Status = responseTipoReporte.Status;
            if (response.Status.Exito == 1)
            {
                ReportesCiudadanos[i].TipoReporteCiudadano = responseTipoReporte.Data;
            }

            return response;
        }

        private Response<object> OrdenarPaginar()
        {
            Response<object> response = new Response<object>();

            IEnumerable<ReporteCiudadano> reportesCiudadanos;

            switch (FiltroReportesCiudadanos.Orden)
            {
                case 1:
                    reportesCiudadanos = ReportesCiudadanos.OrderBy(d => d.IdReporteCiudadano);
                    break;
                case 2:
                    reportesCiudadanos = ReportesCiudadanos.OrderByDescending(d => d.IdReporteCiudadano);
                    break;
                case 3:
                    reportesCiudadanos = ReportesCiudadanos.OrderBy(d => d.IdTipoReporteCiudadano);
                    break;
                case 4:
                    reportesCiudadanos = ReportesCiudadanos.OrderByDescending(d => d.IdTipoReporteCiudadano);
                    break;
                case 5:
                    reportesCiudadanos = ReportesCiudadanos.OrderBy(d => d.IdEstatusReporteCiudadano);
                    break;
                case 6:
                    reportesCiudadanos = ReportesCiudadanos.OrderByDescending(d => d.IdEstatusReporteCiudadano);
                    break;
                case 7:
                    reportesCiudadanos = ReportesCiudadanos.OrderBy(d => d.VercionesReporteCiudadano.Count);
                    break;
                case 8:
                    reportesCiudadanos = ReportesCiudadanos.OrderByDescending(d => d.VercionesReporteCiudadano.Count);
                    break;
                case 9:
                    reportesCiudadanos = ReportesCiudadanos.OrderBy(d => d.FechaPrimerReporte);
                    break;
                case 10:
                    reportesCiudadanos = ReportesCiudadanos.OrderByDescending(d => d.FechaPrimerReporte);
                    break;
                default:
                    reportesCiudadanos = ReportesCiudadanos.OrderByDescending(d => d.FechaPrimerReporte);
                    break;
            }

            Response<IEnumerable<ReporteCiudadano>> responseReportesCiudadanos = Paginado.Paginar(reportesCiudadanos, FiltroReportesCiudadanos.MaximoElementos, FiltroReportesCiudadanos.Pagina);
            response.Status = responseReportesCiudadanos.Status;
            if (response.Status.Exito == 1)
            {
                ReportesCiudadanos = responseReportesCiudadanos.Data.ToList();
                response.Info = responseReportesCiudadanos.Info;
            }

            return response;
        }
    }
}
