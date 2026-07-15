using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys.Update
{
    public class PagoUpdate
    {
        private UpdateCityApp<Pago> UpdateCityApp;

        public PagoUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Pago>(cityAppContext);
        }

        public Response<object> UpdatePago(Pago pago)
        {
            return UpdateCityApp.Save(pago);
        }
    }
}
