using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys;
using CityApp.Server.Servicios.PayServices;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;

namespace CityApp.Server.Logic.PayLogic
{
    public class RealizarPagoCardLogic
    {
        private PayCard PayCard = new PayCard();
        private PagoTarjeta PagoTarjeta;
        private CityAppContext CityAppContext;
        private PagoQuerys PagoQuerys;


        public RealizarPagoCardLogic(CityAppContext cityAppContext, PagoTarjeta pagoTarjeta)
        {
            CityAppContext = cityAppContext;
            PagoQuerys = new PagoQuerys(cityAppContext);
            PagoTarjeta = pagoTarjeta;
        }

        public Response<Pago> Realizar()
        {
            Response<Pago> response = new Response<Pago>();
            //response = PayCard.Pay(PagoTarjeta);
            Response<PagoTarjeta> responsePagoTarjeta = new Response<PagoTarjeta>();
            responsePagoTarjeta = PayCard.Pay(PagoTarjeta);
            response.Status = responsePagoTarjeta.Status;
            if (response.Status.Exito == 1)
            {
                PagoTarjeta = responsePagoTarjeta.Data;
                response.Data = PagoTarjeta.Pago;
                //Response<object> responseUpdatePago = new Response<object>();
                //responseUpdatePago = PagoQuerys.UpdatePago(PagoTarjeta.Pago);
                //response.Status = responseUpdatePago.Status;
            }
            return response;
        }
    }
}
