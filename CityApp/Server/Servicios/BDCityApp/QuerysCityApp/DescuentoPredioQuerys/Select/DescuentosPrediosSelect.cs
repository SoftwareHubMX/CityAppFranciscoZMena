using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.DescuentoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys.Select
{
    public class DescuentosPrediosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<DescuentoPredio> SelectCityApp = new SelectCityApp<DescuentoPredio>();

        private Paginado<DescuentoPredio> Paginado = new Paginado<DescuentoPredio>();

        public DescuentosPrediosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<DescuentoPredio>> SelectDescuentosPredios(FiltroDescuentoPredios filtroDescuentosPredios)
        {
            Response<IEnumerable<DescuentoPredio>> response = new Response<IEnumerable<DescuentoPredio>>();

            try
            {
                switch (filtroDescuentosPredios.FiltroFechas)
                {
                    case 0:
                        response.Data = CityAppContext.DescuentosPredios;
                        break;
                    case 1:
                        response.Data = CityAppContext.DescuentosPredios.Where(d =>
                        d.FechaFin >= new DateTime(filtroDescuentosPredios.FechaFija.Year, filtroDescuentosPredios.FechaFija.Month, filtroDescuentosPredios.FechaFija.Day, 0, 0, 0)
                        && d.FechaInicio <= new DateTime(filtroDescuentosPredios.FechaFija.Year, filtroDescuentosPredios.FechaFija.Month, filtroDescuentosPredios.FechaFija.Day, 23, 59, 59));
                        break;
                    case 2:
                        response.Data = CityAppContext.DescuentosPredios.Where(d =>
                        d.FechaInicio >= new DateTime(filtroDescuentosPredios.FechaInicio.Year, filtroDescuentosPredios.FechaInicio.Month, filtroDescuentosPredios.FechaInicio.Day, 0, 0, 0)
                        && d.FechaFin <= new DateTime(filtroDescuentosPredios.FechaFin.Year, filtroDescuentosPredios.FechaFin.Month, filtroDescuentosPredios.FechaFin.Day, 23, 59, 59));
                        break;
                    case 3:
                        response.Data = CityAppContext.DescuentosPredios.Where(d =>
                        d.FechaInicio >= new DateTime(filtroDescuentosPredios.Year, 1, 1, 0, 0, 0)
                        && d.FechaFin <= new DateTime(filtroDescuentosPredios.Year, 12, 31, 23, 59, 59));
                        break;
                    case 4:
                        int days = DateTime.DaysInMonth(filtroDescuentosPredios.Year, filtroDescuentosPredios.Mes);
                        response.Data = CityAppContext.DescuentosPredios.Where(d =>
                        d.FechaInicio >= new DateTime(filtroDescuentosPredios.Year, filtroDescuentosPredios.Mes, 1, 0, 0, 0)
                        && d.FechaFin <= new DateTime(filtroDescuentosPredios.Year, filtroDescuentosPredios.Mes, days, 23, 59, 59));
                        break;
                    default:
                        response.Data = CityAppContext.DescuentosPredios;
                        break;
                }

                if (filtroDescuentosPredios.Titulo != "NA")
                {
                    response.Data = response.Data.Where(d => d.TituloDescuento == filtroDescuentosPredios.Titulo);
                }

                if (filtroDescuentosPredios.Descuento != 0)
                {
                    response.Data = response.Data.Where(d => d.PorsentajeMonto == filtroDescuentosPredios.PorsentajeMonto 
                    && d.Descuento == filtroDescuentosPredios.Descuento);
                }

                switch (filtroDescuentosPredios.Orden)
                {
                    case 1:
                        response.Data = response.Data.OrderBy(d => d.IdDescuentoPredio);
                        break;
                    case 2:
                        response.Data = response.Data.OrderByDescending(d => d.IdDescuentoPredio);
                        break;
                    case 3:
                        response.Data = response.Data.OrderBy(d => d.TituloDescuento);
                        break;
                    case 4:
                        response.Data = response.Data.OrderByDescending(d => d.TituloDescuento);
                        break;
                    case 5:
                        response.Data = response.Data.OrderBy(d => d.FechaInicio);
                        break;
                    case 6:
                        response.Data = response.Data.OrderByDescending(d => d.FechaInicio);
                        break;
                    case 7:
                        response.Data = response.Data.OrderBy(d => d.FechaFin);
                        break;
                    case 8:
                        response.Data = response.Data.OrderByDescending(d => d.FechaFin);
                        break;
                    case 9:
                        response.Data = response.Data.OrderBy(d => d.YearResago);
                        break;
                    case 10:
                        response.Data = response.Data.OrderByDescending(d => d.YearResago);
                        break;
                    case 11:
                        response.Data = response.Data.OrderBy(d => d.Descuento);
                        break;
                    case 12:
                        response.Data = response.Data.OrderByDescending(d => d.Descuento);
                        break;
                    default:
                        response.Data = response.Data.OrderByDescending(d => d.IdDescuentoPredio);
                        break;
                }

                response.Status = SelectCityApp.ValidarLista(response.Data);

                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroDescuentosPredios.MaximoElementos, filtroDescuentosPredios.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<DescuentoPredio>> SelectDescuentosPrediosHoy()
        {
            Response<IEnumerable<DescuentoPredio>> response = new Response<IEnumerable<DescuentoPredio>>();

            try
            {
                response.Data = CityAppContext.DescuentosPredios.Where(
                    d => d.FechaInicio <= Fecha.GetFechaMx()
                    && d.FechaFin >= Fecha.GetFechaMx()
                    );
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
