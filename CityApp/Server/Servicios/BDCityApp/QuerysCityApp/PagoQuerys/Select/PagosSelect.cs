using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys.Select
{
    public class PagosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Pago> SelectCityApp = new SelectCityApp<Pago>();

        private Paginado<Pago> Paginado = new Paginado<Pago>();

        public PagosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Pago>> SelectPagosFiltroPagos(FiltroPagos filtroPagos)
        {
            Response<IEnumerable<Pago>> response = new Response<IEnumerable<Pago>>();

            try
            {
                switch (filtroPagos.FiltroFechas)
                {
                    case 0:
                        response.Data = CityAppContext.Pagos;
                        break;
                    case 1:
                        response.Data = CityAppContext.Pagos.Where(d =>
                        d.FechaPago >= new DateTime(filtroPagos.FechaFija.Year, filtroPagos.FechaFija.Month, filtroPagos.FechaFija.Day, 0, 0, 0)
                        && d.FechaPago <= new DateTime(filtroPagos.FechaFija.Year, filtroPagos.FechaFija.Month, filtroPagos.FechaFija.Day, 23, 59, 59));
                        break;
                    case 2:
                        response.Data = CityAppContext.Pagos.Where(d =>
                        d.FechaPago >= new DateTime(filtroPagos.FechaInicio.Year, filtroPagos.FechaInicio.Month, filtroPagos.FechaInicio.Day, 0, 0, 0)
                        && d.FechaPago <= new DateTime(filtroPagos.FechaFin.Year, filtroPagos.FechaFin.Month, filtroPagos.FechaFin.Day, 23, 59, 59));
                        break;
                    case 3:
                        response.Data = CityAppContext.Pagos.Where(d =>
                        d.FechaPago >= new DateTime(filtroPagos.Year, 1, 1, 0, 0, 0)
                        && d.FechaPago <= new DateTime(filtroPagos.Year, 12, 31, 23, 59, 59));
                        break;
                    case 4:
                        int days = DateTime.DaysInMonth(filtroPagos.Year, filtroPagos.Mes);
                        response.Data = CityAppContext.Pagos.Where(d =>
                        d.FechaPago >= new DateTime(filtroPagos.Year, filtroPagos.Mes, 1, 0, 0, 0)
                        && d.FechaPago <= new DateTime(filtroPagos.Year, filtroPagos.Mes, days, 23, 59, 59));
                        break;
                    default:
                        response.Data = CityAppContext.Pagos;
                        break;
                }

                if (filtroPagos.Referencia != "NA")
                {
                    response.Data = response.Data.Where(d => d.Referencia == filtroPagos.Referencia);
                }

                if (filtroPagos.TipoPago != 0)
                {
                    response.Data = response.Data.Where(d => d.IdTipoPago == filtroPagos.TipoPago);
                }

                if (filtroPagos.IdCuenta != 0)
                {
                    response.Data = response.Data.Where(d => d.IdCuenta == filtroPagos.IdCuenta);
                }

                switch (filtroPagos.Orden)
                {
                    case 1:
                        response.Data = response.Data.OrderBy(d => d.IdPago);
                        break;
                    case 2:
                        response.Data = response.Data.OrderByDescending(d => d.IdPago);
                        break;
                    case 3:
                        response.Data = response.Data.OrderBy(d => d.Referencia);
                        break;
                    case 4:
                        response.Data = response.Data.OrderByDescending(d => d.Referencia);
                        break;
                    case 5:
                        response.Data = response.Data.OrderBy(d => d.IdTipoPago);
                        break;
                    case 6:
                        response.Data = response.Data.OrderByDescending(d => d.IdTipoPago);
                        break;
                    case 7:
                        response.Data = response.Data.OrderBy(d => d.IdCuenta);
                        break;
                    case 8:
                        response.Data = response.Data.OrderByDescending(d => d.IdCuenta);
                        break;
                    case 9:
                        response.Data = response.Data.OrderBy(d => d.FechaPago);
                        break;
                    case 10:
                        response.Data = response.Data.OrderByDescending(d => d.FechaPago);
                        break;
                    default:
                        response.Data = response.Data.OrderByDescending(d => d.IdPago);
                        break;
                }

                response.Status = SelectCityApp.ValidarLista(response.Data);

                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroPagos.MaximoNoticias, filtroPagos.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<Pago>> SelectPagosFechasDashBoard(int Year, int mes)
        {
            Response<IEnumerable<Pago>> response = new Response<IEnumerable<Pago>>();

            try
            {
                response.Data = CityAppContext.Pagos.Where(d =>
                d.FechaPago >= new DateTime(Year, mes, 1, 0, 0, 0)
                && d.FechaPago <= new DateTime(Year, mes, DateTime.DaysInMonth(Year, mes), 23, 59, 59));

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<Pago>> SelectPagos()
        {
            Response<IEnumerable<Pago>> response = new Response<IEnumerable<Pago>>();

            try
            {
                response.Data = CityAppContext.Pagos.OrderByDescending(d => d.IdPago);

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<Pago> SelectPagoIdPago(int idPago)
        {
            Response<Pago> response = new Response<Pago>();

            try
            {
                response.Data = CityAppContext.Pagos.Where(d => d.IdPago == idPago).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
