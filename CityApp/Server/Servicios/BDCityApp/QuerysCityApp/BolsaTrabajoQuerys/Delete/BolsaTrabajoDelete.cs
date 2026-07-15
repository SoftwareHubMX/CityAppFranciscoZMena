using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys.Delete
{
    public class BolsaTrabajoDelete
    {
        private DeleteCityApp<BolsaTrabajo> DeleteCityApp;
        public BolsaTrabajoDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<BolsaTrabajo>(cityAppContext);
        }
        public Response<object> DeleteBolsaTrabajo(BolsaTrabajo bolsaTrabajo)
        {
            return DeleteCityApp.Save(bolsaTrabajo);
        }
    }
}
