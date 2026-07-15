using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContadorAccesoQuerys.Insert
{
    public class ContadorAccesoInsert
    {
        private InsertCityApp<ContadorAcceso> InsertCityApp;

        public ContadorAccesoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ContadorAcceso>(cityAppContext);
        }

        public Response<object> InsertContadorAcceso(ContadorAcceso contadorAcceso)
        {
            return InsertCityApp.Save(contadorAcceso);
        }
    }
}
