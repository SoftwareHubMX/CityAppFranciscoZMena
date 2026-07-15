using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;

namespace CityApp.Server.Logic.PagoLogic
{
    public class ActualizarPagoLogic
    {
        private PagoQuerys PagoQuerys;
        private Pago Pago;
        public ActualizarPagoLogic(CityAppContext cityAppContext, Pago pago)
        {
            PagoQuerys = new PagoQuerys(cityAppContext);

            Pago = pago;
        }

        public Response<object> Actualizar()
        {
            return PagoQuerys.UpdatePago(Pago);
        }
    }
}
