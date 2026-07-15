using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.GeolocalizacionModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Linq;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys.Select
{
    public class ReportesCiudadanosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ReporteCiudadano> SelectCityApp = new SelectCityApp<ReporteCiudadano>();

        public ReportesCiudadanosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ReporteCiudadano>> SelectReportesCiudadanosFiltros(FiltroReportesCiudadanos filtroReportesCiudadanos)
        {
            Response<IEnumerable<ReporteCiudadano>> response = new Response<IEnumerable<ReporteCiudadano>>();

            try
            {
                //response.Data = from data in CityAppContext.VercionesReporteCiudadano
                //                orderby data.IdVercionReporteCiudadano
                //                where (filtroReportesCiudadanos.Localidad != "NA") ? 
                //                    data.DireccionReporteCiudadano.Localidad == filtroReportesCiudadanos.Localidad 
                //                    : true
                //                    && (filtroReportesCiudadanos.Colonia != "NA") ? 
                //                    data.DireccionReporteCiudadano.Colonia == filtroReportesCiudadanos.Colonia 
                //                    : true
                //                    && (filtroReportesCiudadanos.CodigoPostal != "NA") ? 
                //                    data.DireccionReporteCiudadano.CodigoPostal == filtroReportesCiudadanos.CodigoPostal 
                //                    : true
                //                    && (filtroReportesCiudadanos.NombreUsuario != "NA") ?
                //                    data.Cuenta.NombreUsuario == filtroReportesCiudadanos.NombreUsuario
                //                    : true
                //                select new ReporteCiudadano()
                //                {
                //                    IdReporteCiudadano = data.ReporteCiudadano.IdReporteCiudadano,
                //                    IdTipoReporteCiudadano = data.ReporteCiudadano.IdTipoReporteCiudadano,
                //                    IdEstatusReporteCiudadano = data.ReporteCiudadano.IdEstatusReporteCiudadano,
                //                    FechaPrimerReporte = data.ReporteCiudadano.FechaPrimerReporte,
                //                    TipoReporteCiudadano = data.ReporteCiudadano.TipoReporteCiudadano,
                //                    EstatusReporteCiudadano = data.ReporteCiudadano.EstatusReporteCiudadano,
                //                };

                response.Data = CityAppContext.ReportesCiudadanos.
                    Where(d => d.VercionesReporteCiudadano.
                    Any(data => 
                    (filtroReportesCiudadanos.Localidad != "NA") ? data.DireccionReporteCiudadano.Localidad == filtroReportesCiudadanos.Localidad : true
                    && (filtroReportesCiudadanos.Colonia != "NA") ? data.DireccionReporteCiudadano.Colonia == filtroReportesCiudadanos.Colonia : true
                    && (filtroReportesCiudadanos.CodigoPostal != "NA") ? data.DireccionReporteCiudadano.CodigoPostal == filtroReportesCiudadanos.CodigoPostal : true
                    && (filtroReportesCiudadanos.NombreUsuario != "NA") ? data.Cuenta.NombreUsuario == filtroReportesCiudadanos.NombreUsuario : true)
                    && (filtroReportesCiudadanos.IdTipoReporteCiudadano != 0) ? d.IdTipoReporteCiudadano == filtroReportesCiudadanos.IdTipoReporteCiudadano : true
                    && (filtroReportesCiudadanos.IdReporteCiudadano != 0) ? d.IdReporteCiudadano == filtroReportesCiudadanos.IdReporteCiudadano : true
                    && (filtroReportesCiudadanos.IdEstatusReporteCiudadano != 0) ? d.IdEstatusReporteCiudadano == filtroReportesCiudadanos.IdEstatusReporteCiudadano : true
                    && (filtroReportesCiudadanos.NumeroReportes > 0) ? d.VercionesReporteCiudadano.Count == filtroReportesCiudadanos.NumeroReportes 
                    : ((filtroReportesCiudadanos.MinimoReportes > 0) ? d.VercionesReporteCiudadano.Count > filtroReportesCiudadanos.MinimoReportes : true
                    || (filtroReportesCiudadanos.MaximoReportes > 0) ? d.VercionesReporteCiudadano.Count < filtroReportesCiudadanos.MaximoReportes : true)
                    && (filtroReportesCiudadanos.FiltroFechas == 1) ?
                        d.FechaPrimerReporte >= new DateTime(filtroReportesCiudadanos.FechaFija.Year, filtroReportesCiudadanos.FechaFija.Month, filtroReportesCiudadanos.FechaFija.Day, 0, 0, 0)
                        && d.FechaPrimerReporte <= new DateTime(filtroReportesCiudadanos.FechaFija.Year, filtroReportesCiudadanos.FechaFija.Month, filtroReportesCiudadanos.FechaFija.Day, 23, 59, 59)
                    : (filtroReportesCiudadanos.FiltroFechas == 2) ?
                        d.FechaPrimerReporte >= new DateTime(filtroReportesCiudadanos.FechaInicio.Year, filtroReportesCiudadanos.FechaInicio.Month, filtroReportesCiudadanos.FechaInicio.Day, 0, 0, 0)
                        && d.FechaPrimerReporte <= new DateTime(filtroReportesCiudadanos.FechaFin.Year, filtroReportesCiudadanos.FechaFin.Month, filtroReportesCiudadanos.FechaFin.Day, 23, 59, 59)
                    : (filtroReportesCiudadanos.FiltroFechas == 3) ?
                        d.FechaPrimerReporte >= new DateTime(filtroReportesCiudadanos.Year, 1, 1, 0, 0, 0)
                        && d.FechaPrimerReporte <= new DateTime(filtroReportesCiudadanos.Year, 12, 31, 23, 59, 59)
                    : (filtroReportesCiudadanos.FiltroFechas == 4) ?
                        d.FechaPrimerReporte >= new DateTime(filtroReportesCiudadanos.Year, filtroReportesCiudadanos.Mes, 1, 0, 0, 0)
                        && d.FechaPrimerReporte <= new DateTime(filtroReportesCiudadanos.Year, filtroReportesCiudadanos.Mes, DateTime.DaysInMonth(filtroReportesCiudadanos.Year, filtroReportesCiudadanos.Mes), 23, 59, 59)
                    : true);

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<ReporteCiudadano>> SelectReportesCiudadanosIdCuentaFiltros(int idCuenta, FiltroReportesCiudadanos filtroReportesCiudadanos)
        {
            Response<IEnumerable<ReporteCiudadano>> response = new Response<IEnumerable<ReporteCiudadano>>();

            try
            {
                response.Data = from data in CityAppContext.VercionesReporteCiudadano
                                orderby data.IdReporteCiudadano
                                where data.IdCuenta == idCuenta
                                select new ReporteCiudadano()
                                {
                                    IdReporteCiudadano = data.ReporteCiudadano.IdReporteCiudadano,
                                    IdTipoReporteCiudadano = data.ReporteCiudadano.IdTipoReporteCiudadano,
                                    IdEstatusReporteCiudadano = data.ReporteCiudadano.IdEstatusReporteCiudadano,
                                    FechaPrimerReporte = data.ReporteCiudadano.FechaPrimerReporte,
                                    TipoReporteCiudadano = data.ReporteCiudadano.TipoReporteCiudadano,
                                    Observaciones = data.ReporteCiudadano.Observaciones,
                                    VercionesReporteCiudadano = new List<VercionReporteCiudadano>()
                                    {
                                        new VercionReporteCiudadano()
                                        {
                                            IdVercionReporteCiudadano = data.IdVercionReporteCiudadano,
                                            Descripcion = data.Descripcion,
                                            FechaReporte = data.FechaReporte,
                                            IdReporteCiudadano = data.IdReporteCiudadano,
                                            IdCuenta = data.IdCuenta,
                                            DireccionReporteCiudadano = data.DireccionReporteCiudadano,
                                        }
                                    }
                                };

                response.Status = SelectCityApp.ValidarLista(response.Data);

                if(response.Status.Exito == 1)
                {
                    response.Data = response.Data.
                    Where(d => d.VercionesReporteCiudadano.
                    Any(data =>
                    (filtroReportesCiudadanos.Localidad != "NA") ? data.DireccionReporteCiudadano.Localidad == filtroReportesCiudadanos.Localidad : true
                    && (filtroReportesCiudadanos.Colonia != "NA") ? data.DireccionReporteCiudadano.Colonia == filtroReportesCiudadanos.Colonia : true
                    && (filtroReportesCiudadanos.CodigoPostal != "NA") ? data.DireccionReporteCiudadano.CodigoPostal == filtroReportesCiudadanos.CodigoPostal : true)
                    && (filtroReportesCiudadanos.IdTipoReporteCiudadano != 0) ? d.IdTipoReporteCiudadano == filtroReportesCiudadanos.IdTipoReporteCiudadano : true
                    && (filtroReportesCiudadanos.IdEstatusReporteCiudadano != 0) ? d.IdEstatusReporteCiudadano == filtroReportesCiudadanos.IdEstatusReporteCiudadano : true
                    && (filtroReportesCiudadanos.MinimoReportes > 0) ? d.VercionesReporteCiudadano.Count > filtroReportesCiudadanos.MinimoReportes : true
                    && (filtroReportesCiudadanos.MaximoReportes > 0) ? d.VercionesReporteCiudadano.Count < filtroReportesCiudadanos.MaximoReportes : true
                    && (filtroReportesCiudadanos.FiltroFechas == 1) ?
                        d.FechaPrimerReporte >= new DateTime(filtroReportesCiudadanos.FechaFija.Year, filtroReportesCiudadanos.FechaFija.Month, filtroReportesCiudadanos.FechaFija.Day, 0, 0, 0)
                        && d.FechaPrimerReporte <= new DateTime(filtroReportesCiudadanos.FechaFija.Year, filtroReportesCiudadanos.FechaFija.Month, filtroReportesCiudadanos.FechaFija.Day, 23, 59, 59)
                    : (filtroReportesCiudadanos.FiltroFechas == 2) ?
                        d.FechaPrimerReporte >= new DateTime(filtroReportesCiudadanos.FechaInicio.Year, filtroReportesCiudadanos.FechaInicio.Month, filtroReportesCiudadanos.FechaInicio.Day, 0, 0, 0)
                        && d.FechaPrimerReporte <= new DateTime(filtroReportesCiudadanos.FechaFin.Year, filtroReportesCiudadanos.FechaFin.Month, filtroReportesCiudadanos.FechaFin.Day, 23, 59, 59)
                    : (filtroReportesCiudadanos.FiltroFechas == 3) ?
                        d.FechaPrimerReporte >= new DateTime(filtroReportesCiudadanos.Year, 1, 1, 0, 0, 0)
                        && d.FechaPrimerReporte <= new DateTime(filtroReportesCiudadanos.Year, 12, 31, 23, 59, 59)
                    : (filtroReportesCiudadanos.FiltroFechas == 4) ?
                        d.FechaPrimerReporte >= new DateTime(filtroReportesCiudadanos.Year, filtroReportesCiudadanos.Mes, 1, 0, 0, 0)
                        && d.FechaPrimerReporte <= new DateTime(filtroReportesCiudadanos.Year, filtroReportesCiudadanos.Mes, DateTime.DaysInMonth(filtroReportesCiudadanos.Year, filtroReportesCiudadanos.Mes), 23, 59, 59)
                    : true);
                }

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<ReporteCiudadano>> SelectReportesCiudadanosEstatusReporteCiudadanoDash(int idEstusReporteCiudadano, FechasDashBoard fechasDashBoard)
        {
            Response<IEnumerable<ReporteCiudadano>> response = new Response<IEnumerable<ReporteCiudadano>>();

            try
            {

                response.Data = from data in CityAppContext.ReportesCiudadanos
                                orderby data.IdReporteCiudadano
                                where data.IdEstatusReporteCiudadano == idEstusReporteCiudadano
                                 && data.FechaPrimerReporte.Year == fechasDashBoard.Year
                                 && data.FechaPrimerReporte.Month == fechasDashBoard.Mes
                                select new ReporteCiudadano()
                                {
                                    IdReporteCiudadano = data.IdReporteCiudadano,
                                    IdTipoReporteCiudadano = data.IdTipoReporteCiudadano,
                                    IdEstatusReporteCiudadano = data.IdEstatusReporteCiudadano,
                                    FechaPrimerReporte = data.FechaPrimerReporte,
                                    TipoReporteCiudadano = data.TipoReporteCiudadano,
                                    Observaciones = data.Observaciones,

                                };

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<ReporteCiudadano>> SelectReportesCiudadanosEstatusReporteCiudadano(int idEstusReporteCiudadano, FechasDashBoard fechasDashBoard)
        {
            Response<IEnumerable<ReporteCiudadano>> response = new Response<IEnumerable<ReporteCiudadano>>();

            try
            {
                response.Data = from data in CityAppContext.VercionesReporteCiudadano
                                orderby data.IdReporteCiudadano
                                where data.ReporteCiudadano.IdEstatusReporteCiudadano == idEstusReporteCiudadano
                                select new ReporteCiudadano()
                                {
                                    IdReporteCiudadano = data.ReporteCiudadano.IdReporteCiudadano,
                                    IdTipoReporteCiudadano = data.ReporteCiudadano.IdTipoReporteCiudadano,
                                    IdEstatusReporteCiudadano = data.ReporteCiudadano.IdEstatusReporteCiudadano,
                                    FechaPrimerReporte = data.ReporteCiudadano.FechaPrimerReporte,
                                    TipoReporteCiudadano = data.ReporteCiudadano.TipoReporteCiudadano,
                                    Observaciones = data.ReporteCiudadano.Observaciones,
                                    VercionesReporteCiudadano = new List<VercionReporteCiudadano>()
                                    {
                                        new VercionReporteCiudadano()
                                        {
                                            IdVercionReporteCiudadano = data.IdVercionReporteCiudadano,
                                            Descripcion = data.Descripcion,
                                            FechaReporte = data.FechaReporte,
                                            IdReporteCiudadano = data.IdReporteCiudadano,
                                            IdCuenta = data.IdCuenta,
                                            DireccionReporteCiudadano = data.DireccionReporteCiudadano,
                                        }
                                    }
                                };

                response.Status = SelectCityApp.ValidarLista(response.Data);
                if(response.Status.Exito == 1)
                {
                    response.Data = CityAppContext.ReportesCiudadanos.
                     Where(d => d.VercionesReporteCiudadano.
                     Any(data =>
                     (fechasDashBoard.TipoFecha == 0) ?
                         d.FechaPrimerReporte >= new DateTime(DateTime.UtcNow.AddHours(-6).Year, DateTime.UtcNow.AddHours(-6).Month, DateTime.UtcNow.AddHours(-6).Day, 0, 0, 0)
                         && d.FechaPrimerReporte <= new DateTime(DateTime.UtcNow.AddHours(-6).Year, DateTime.UtcNow.AddHours(-6).Month, DateTime.UtcNow.AddHours(-6).Day, 23, 59, 59)
                     : (fechasDashBoard.TipoFecha == 1) ?
                         d.FechaPrimerReporte >= new DateTime(fechasDashBoard.Year, fechasDashBoard.Mes, 1, 0, 0, 0)
                         && d.FechaPrimerReporte <= new DateTime(fechasDashBoard.Year, fechasDashBoard.Mes, DateTime.DaysInMonth(fechasDashBoard.Year, fechasDashBoard.Mes), 23, 59, 59)
                     : (fechasDashBoard.TipoFecha == 3) ?
                         d.FechaPrimerReporte >= new DateTime(fechasDashBoard.Year, 1, 1, 0, 0, 0)
                         && d.FechaPrimerReporte <= new DateTime(fechasDashBoard.Year, 12, 31, 23, 59, 59)
                     : (fechasDashBoard.TipoFecha == 2) ?
                         d.FechaPrimerReporte >= new DateTime(fechasDashBoard.Year, 1, 1, 0, 0, 0)
                         && d.FechaPrimerReporte <= new DateTime(fechasDashBoard.Year2, 12, 31, 23, 59, 59)
                     : true));
                }

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
