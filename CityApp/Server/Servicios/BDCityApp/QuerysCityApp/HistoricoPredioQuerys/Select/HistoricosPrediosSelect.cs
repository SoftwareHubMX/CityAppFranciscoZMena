using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.HistoricoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys.Select
{
    public class HistoricosPrediosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<HistoricoPredio> SelectCityApp = new SelectCityApp<HistoricoPredio>();

        private Paginado<HistoricoPredio> Paginado = new Paginado<HistoricoPredio>();

        public HistoricosPrediosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<HistoricoPredio>> SelectHistoricosPrediosFiltroHistoricosPredios(FiltroHistoricoPredio filtroHistoricosPredios)
        {
            Response<IEnumerable<HistoricoPredio>> response = new Response<IEnumerable<HistoricoPredio>>();

            try
            {
                switch (filtroHistoricosPredios.FiltroFechas)
                {
                    case 0:
                        response.Data = CityAppContext.HistoricosPredios;
                        break;
                    case 1:
                        response.Data = CityAppContext.HistoricosPredios.Where(d =>
                        d.FechaHistorico >= new DateTime(filtroHistoricosPredios.FechaFija.Year, filtroHistoricosPredios.FechaFija.Month, filtroHistoricosPredios.FechaFija.Day, 0, 0, 0)
                        && d.FechaHistorico <= new DateTime(filtroHistoricosPredios.FechaFija.Year, filtroHistoricosPredios.FechaFija.Month, filtroHistoricosPredios.FechaFija.Day, 23, 59, 59));
                        break;
                    case 2:
                        response.Data = CityAppContext.HistoricosPredios.Where(d =>
                        d.FechaHistorico >= new DateTime(filtroHistoricosPredios.FechaInicio.Year, filtroHistoricosPredios.FechaInicio.Month, filtroHistoricosPredios.FechaInicio.Day, 0, 0, 0)
                        && d.FechaHistorico <= new DateTime(filtroHistoricosPredios.FechaFin.Year, filtroHistoricosPredios.FechaFin.Month, filtroHistoricosPredios.FechaFin.Day, 23, 59, 59));
                        break;
                    case 3:
                        response.Data = CityAppContext.HistoricosPredios.Where(d =>
                        d.FechaHistorico >= new DateTime(filtroHistoricosPredios.Year, 1, 1, 0, 0, 0)
                        && d.FechaHistorico <= new DateTime(filtroHistoricosPredios.Year, 12, 31, 23, 59, 59));
                        break;
                    case 4:
                        int days = DateTime.DaysInMonth(filtroHistoricosPredios.Year, filtroHistoricosPredios.Mes);
                        response.Data = CityAppContext.HistoricosPredios.Where(d =>
                        d.FechaHistorico >= new DateTime(filtroHistoricosPredios.Year, filtroHistoricosPredios.Mes, 1, 0, 0, 0)
                        && d.FechaHistorico <= new DateTime(filtroHistoricosPredios.Year, filtroHistoricosPredios.Mes, days, 23, 59, 59));
                        break;
                    default:
                        response.Data = CityAppContext.HistoricosPredios;
                        break;
                }

                switch (filtroHistoricosPredios.Orden)
                {
                    case 1:
                        response.Data = response.Data.OrderBy(d => d.IdHistoricoPredio);
                        break;
                    case 2:
                        response.Data = response.Data.OrderByDescending(d => d.IdHistoricoPredio);
                        break;
                    case 3:
                        response.Data = response.Data.OrderBy(d => d.NotaActualizacion);
                        break;
                    case 4:
                        response.Data = response.Data.OrderByDescending(d => d.NotaActualizacion);
                        break;
                    case 5:
                        response.Data = response.Data.OrderBy(d => d.FechaHistorico);
                        break;
                    case 6:
                        response.Data = response.Data.OrderByDescending(d => d.FechaHistorico);
                        break;
                    case 7:
                        response.Data = response.Data.OrderBy(d => d.IdCuenta);
                        break;
                    case 8:
                        response.Data = response.Data.OrderByDescending(d => d.IdCuenta);
                        break;
                    default:
                        response.Data = response.Data.OrderByDescending(d => d.IdHistoricoPredio);
                        break;
                }

                response.Status = SelectCityApp.ValidarLista(response.Data);

                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroHistoricosPredios.MaximoElementos, filtroHistoricosPredios.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
