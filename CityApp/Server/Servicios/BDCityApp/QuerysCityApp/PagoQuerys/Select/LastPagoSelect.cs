using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys.Select
{
    public class LastPagoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Pago> SelectCityApp = new SelectCityApp<Pago>();

        public LastPagoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Pago> SelectLastPago(int idCuenta, DateTime fecha)
        {
            Response<Pago> response = new Response<Pago>();

            try
            {
                response.Data = (from data in CityAppContext.Pagos
                                 where data.IdCuenta == idCuenta
                                 && data.FechaPago == fecha
                                 select new Pago()
                                 {
                                     IdPago = data.IdPago,
                                     FechaPago = data.FechaPago,
                                     Referencia = data.Referencia,
                                     Identificador = data.Identificador,
                                     Folio = data.Folio,
                                     Total = data.Total,
                                     IdTipoPago = data.IdTipoPago,
                                     IdCuenta = data.IdCuenta,
                                     IdEstatusPago = data.IdEstatusPago,
                                     TipoPago = null,
                                     Cuenta = null,
                                     EstatusPago = null,
                                 }).FirstOrDefault();

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