using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AgendaEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AgendaQuerys.Select
{
    public class AgendasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Agenda> SelectCityApp = new SelectCityApp<Agenda>();

        private Paginado<Agenda> Paginado = new Paginado<Agenda>();

        public AgendasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Agenda>> SelectAgendasFiltroAgendas(FiltroAgenda filtroAgendas)
        {
            Response<IEnumerable<Agenda>> response = new Response<IEnumerable<Agenda>>();

            try
            {
                switch (filtroAgendas.FiltroFechas)
                {
                    case 0:
                        response.Data = CityAppContext.Agendas;
                        break;
                    case 1:
                        response.Data = CityAppContext.Agendas.Where(d =>
                        d.FechaPublicacion >= new DateTime(filtroAgendas.FechaFija.Year, filtroAgendas.FechaFija.Month, filtroAgendas.FechaFija.Day, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(filtroAgendas.FechaFija.Year, filtroAgendas.FechaFija.Month, filtroAgendas.FechaFija.Day, 23, 59, 59));
                        break;
                    case 2:
                        response.Data = CityAppContext.Agendas.Where(d =>
                        d.FechaPublicacion >= new DateTime(filtroAgendas.FechaInicio.Year, filtroAgendas.FechaInicio.Month, filtroAgendas.FechaInicio.Day, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(filtroAgendas.FechaFin.Year, filtroAgendas.FechaFin.Month, filtroAgendas.FechaFin.Day, 23, 59, 59));
                        break;
                    case 3:
                        response.Data = CityAppContext.Agendas.Where(d =>
                        d.FechaPublicacion >= new DateTime(filtroAgendas.Year, 1, 1, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(filtroAgendas.Year, 12, 31, 23, 59, 59));
                        break;
                    case 4:
                        int days = DateTime.DaysInMonth(filtroAgendas.Year, filtroAgendas.Mes);
                        response.Data = CityAppContext.Agendas.Where(d =>
                        d.FechaPublicacion >= new DateTime(filtroAgendas.Year, filtroAgendas.Mes, 1, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(filtroAgendas.Year, filtroAgendas.Mes, days, 23, 59, 59));
                        break;
                    default:
                        response.Data = CityAppContext.Agendas;
                        break;
                }

                if (filtroAgendas.Titulo != "NA")
                {
                    response.Data = response.Data.Where(d => d.Titulo == filtroAgendas.Titulo);
                }

                if (filtroAgendas.Horario != TimeSpan.Zero)
                {
                    response.Data = response.Data.Where(d => d.Hora == filtroAgendas.Horario);
                }

                if (filtroAgendas.Lugar != "NA")
                {
                    response.Data = response.Data.Where(d => d.Lugar == filtroAgendas.Lugar);
                }

                if (filtroAgendas.Busqueda != "NA")
                {
                    response.Data = response.Data.Where(d =>
                    d.Titulo.Contains(filtroAgendas.Busqueda) || d.Texto.Contains(filtroAgendas.Busqueda));
                }

                switch (filtroAgendas.Orden)
                {
                    case 1:
                        response.Data = response.Data.OrderBy(d => d.IdAgenda);
                        break;
                    case 2:
                        response.Data = response.Data.OrderByDescending(d => d.IdAgenda);
                        break;
                    case 3:
                        response.Data = response.Data.OrderBy(d => d.Titulo);
                        break;
                    case 4:
                        response.Data = response.Data.OrderByDescending(d => d.Titulo);
                        break;
                    case 5:
                        response.Data = response.Data.OrderBy(d => d.Texto);
                        break;
                    case 6:
                        response.Data = response.Data.OrderByDescending(d => d.Texto);
                        break;
                    case 7:
                        response.Data = response.Data.OrderBy(d => d.FechaPublicacion);
                        break;
                    case 8:
                        response.Data = response.Data.OrderByDescending(d => d.FechaPublicacion);
                        break;
                    case 9:
                        response.Data = response.Data.OrderBy(d => d.Hora);
                        break;
                    case 10:
                        response.Data = response.Data.OrderByDescending(d => d.Hora);
                        break;
                    case 11:
                        response.Data = response.Data.OrderBy(d => d.Lugar);
                        break;
                    case 12:
                        response.Data = response.Data.OrderByDescending(d => d.Lugar);
                        break;
                    default:
                        response.Data = response.Data.OrderByDescending(d => d.IdAgenda);
                        break;
                }

                response.Status = SelectCityApp.ValidarLista(response.Data);

                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroAgendas.MaximoElementos, filtroAgendas.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<int> SelectAgendasFechasDashBoard(FechasDashBoard fechasDashBoard)
        {
            Response<int> response = new Response<int>();
            Response<IEnumerable<Agenda>> responseAgendas = new Response<IEnumerable<Agenda>>();

            try
            {
                switch (fechasDashBoard.TipoFecha)
                {
                    case 0:
                        responseAgendas.Data = CityAppContext.Agendas.Where(d =>
                        d.FechaPublicacion >= new DateTime(DateTime.UtcNow.AddHours(-6).Year, DateTime.UtcNow.AddHours(-6).Month, DateTime.UtcNow.AddHours(-6).Day, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(DateTime.UtcNow.AddHours(-6).Year, DateTime.UtcNow.AddHours(-6).Month, DateTime.UtcNow.AddHours(-6).Day, 23, 59, 59));
                        break;
                    case 1:
                        responseAgendas.Data = CityAppContext.Agendas.Where(d =>
                        d.FechaPublicacion >= new DateTime(fechasDashBoard.Year, fechasDashBoard.Mes, 1, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(fechasDashBoard.Year, fechasDashBoard.Mes, DateTime.DaysInMonth(fechasDashBoard.Year, fechasDashBoard.Mes), 23, 59, 59));
                        break;
                    case 2:
                        responseAgendas.Data = CityAppContext.Agendas.Where(d =>
                        d.FechaPublicacion >= new DateTime(fechasDashBoard.Year, 1, 1, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(fechasDashBoard.Year2, 12, 31, 23, 59, 59));
                        break;
                    case 3:
                        responseAgendas.Data = CityAppContext.Agendas.Where(d =>
                        d.FechaPublicacion >= new DateTime(fechasDashBoard.Year, 1, 1, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(fechasDashBoard.Year, 12, 31, 23, 59, 59));
                        break;
                    default:
                        responseAgendas.Data = CityAppContext.Agendas;
                        break;
                }

                response.Status = SelectCityApp.ValidarLista(responseAgendas.Data);

                if (response.Status.Exito == 1)
                {
                    response.Data = responseAgendas.Data.Count();
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
