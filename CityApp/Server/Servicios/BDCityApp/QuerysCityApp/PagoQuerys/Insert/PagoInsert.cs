using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PagoQuerys.Insert
{
    public class PagoInsert
    {
        private InsertCityApp<Pago> InsertCityApp;

        public PagoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Pago>(cityAppContext);
        }

        public Response<object> InsertPago(Pago pago)
        {
            return InsertCityApp.Save(pago);
        }
    }
}
