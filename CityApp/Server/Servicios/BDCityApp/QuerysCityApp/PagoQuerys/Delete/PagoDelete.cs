using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys.Delete
{
    public class PagoDelete
    {
        private DeleteCityApp<Pago> DeleteCityApp;

        public PagoDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Pago>(cityAppContext);
        }

        public Response<object> DeletePago(Pago pago)
        {
            return DeleteCityApp.Save(pago);
        }
    }
}
