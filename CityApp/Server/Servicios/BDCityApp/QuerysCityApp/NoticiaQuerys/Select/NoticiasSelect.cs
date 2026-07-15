using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys.Select
{
    public class NoticiasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Noticia> SelectCityApp = new SelectCityApp<Noticia>();

        private Paginado<Noticia> Paginado = new Paginado<Noticia>();

        public NoticiasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Noticia>> SelectNoticiasFiltroNoticias(FiltroNoticias filtroNoticias)
        {
            Response<IEnumerable<Noticia>> response = new Response<IEnumerable<Noticia>>();

            try
            {
                switch (filtroNoticias.FiltroFechas)
                {
                    case 0:
                        response.Data = CityAppContext.Noticias;
                        break;
                    case 1:
                        response.Data = CityAppContext.Noticias.Where(d => 
                        d.FechaPublicacion >= new DateTime(filtroNoticias.FechaFija.Year, filtroNoticias.FechaFija.Month, filtroNoticias.FechaFija.Day, 0, 0, 0) 
                        && d.FechaPublicacion <= new DateTime(filtroNoticias.FechaFija.Year, filtroNoticias.FechaFija.Month, filtroNoticias.FechaFija.Day, 23, 59, 59));
                        break;
                    case 2:
                        response.Data = CityAppContext.Noticias.Where(d =>
                        d.FechaPublicacion >= new DateTime(filtroNoticias.FechaInicio.Year, filtroNoticias.FechaInicio.Month, filtroNoticias.FechaInicio.Day, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(filtroNoticias.FechaFin.Year, filtroNoticias.FechaFin.Month, filtroNoticias.FechaFin.Day, 23, 59, 59));
                        break;
                    case 3:
                        response.Data = CityAppContext.Noticias.Where(d =>
                        d.FechaPublicacion >= new DateTime(filtroNoticias.Year, 1, 1, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(filtroNoticias.Year, 12, 31, 23, 59, 59));
                        break;
                    case 4:
                        int days = DateTime.DaysInMonth(filtroNoticias.Year, filtroNoticias.Mes);
                        response.Data = CityAppContext.Noticias.Where(d =>
                        d.FechaPublicacion >= new DateTime(filtroNoticias.Year, filtroNoticias.Mes, 1, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(filtroNoticias.Year, filtroNoticias.Mes, days, 23, 59, 59));
                        break;
                    default:
                        response.Data = CityAppContext.Noticias;
                        break;
                }

                if (filtroNoticias.Fuente != "NA")
                {
                    response.Data = response.Data.Where(d => d.Fuente == filtroNoticias.Fuente);
                }

                if (filtroNoticias.Autor != "NA")
                {
                    response.Data = response.Data.Where(d => d.Autor == filtroNoticias.Autor);
                }

                if (filtroNoticias.Busqueda != "NA")
                {
                    response.Data = response.Data.Where(d => 
                    d.Titulo.Contains(filtroNoticias.Busqueda) || d.Texto.Contains(filtroNoticias.Busqueda));
                }

                switch (filtroNoticias.Orden)
                {
                    case 1:
                        response.Data = response.Data.OrderBy(d => d.IdNoticia);
                        break;
                    case 2:
                        response.Data = response.Data.OrderByDescending(d => d.IdNoticia);
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
                        response.Data = response.Data.OrderBy(d => d.Fuente);
                        break;
                    case 8:
                        response.Data = response.Data.OrderByDescending(d => d.Fuente);
                        break;
                    case 9:
                        response.Data = response.Data.OrderBy(d => d.Autor);
                        break;
                    case 10:
                        response.Data = response.Data.OrderByDescending(d => d.Autor);
                        break;
                    case 11:
                        response.Data = response.Data.OrderBy(d => d.FechaPublicacion);
                        break;
                    case 12:
                        response.Data = response.Data.OrderByDescending(d => d.FechaPublicacion);
                        break;
                    default:
                        response.Data = response.Data.OrderByDescending(d => d.IdNoticia);
                        break;
                }

                response.Status = SelectCityApp.ValidarLista(response.Data);

                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroNoticias.MaximoNoticias, filtroNoticias.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<int> SelectNoticiasFechasDashBoard(FechasDashBoard fechasDashBoard)
        {
            Response<int> response = new Response<int>();
            Response<IEnumerable<Noticia>> responseNoticias = new Response<IEnumerable<Noticia>>();

            try
            {
                switch (fechasDashBoard.TipoFecha)
                {
                    case 0:
                        responseNoticias.Data = CityAppContext.Noticias.Where(d =>
                        d.FechaPublicacion >= new DateTime(DateTime.UtcNow.AddHours(-6).Year, DateTime.UtcNow.AddHours(-6).Month, DateTime.UtcNow.AddHours(-6).Day, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(DateTime.UtcNow.AddHours(-6).Year, DateTime.UtcNow.AddHours(-6).Month, DateTime.UtcNow.AddHours(-6).Day, 23, 59, 59));
                        break;
                    case 1:
                        responseNoticias.Data = CityAppContext.Noticias.Where(d =>
                        d.FechaPublicacion >= new DateTime(fechasDashBoard.Year, fechasDashBoard.Mes, 1, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(fechasDashBoard.Year, fechasDashBoard.Mes, DateTime.DaysInMonth(fechasDashBoard.Year, fechasDashBoard.Mes), 23, 59, 59));
                        break;
                    case 2:
                        responseNoticias.Data = CityAppContext.Noticias.Where(d =>
                        d.FechaPublicacion >= new DateTime(fechasDashBoard.Year, 1, 1, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(fechasDashBoard.Year2, 12, 31, 23, 59, 59));
                        break;
                    case 3:
                        responseNoticias.Data = CityAppContext.Noticias.Where(d =>
                        d.FechaPublicacion >= new DateTime(fechasDashBoard.Year, 1, 1, 0, 0, 0)
                        && d.FechaPublicacion <= new DateTime(fechasDashBoard.Year, 12, 31, 23, 59, 59));
                        break;
                    default:
                        responseNoticias.Data = CityAppContext.Noticias;
                        break;
                }

                response.Status = SelectCityApp.ValidarLista(responseNoticias.Data);

                if (response.Status.Exito == 1)
                {
                    response.Data = responseNoticias.Data.Count();
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
