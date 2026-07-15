using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys.Insert
{
    public class BolsaTrabajoInsert
    {
        private InsertCityApp<BolsaTrabajo> InsertCityApp;
        public BolsaTrabajoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<BolsaTrabajo>(cityAppContext);
        }
        public Response<object> InsertBolsaTrabajo(BolsaTrabajo bolsaTrabajo)
        {
            return InsertCityApp.Save(bolsaTrabajo);
        }
    }
}
