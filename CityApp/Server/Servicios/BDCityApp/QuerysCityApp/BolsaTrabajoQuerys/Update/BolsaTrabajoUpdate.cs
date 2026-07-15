using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys.Update
{
    public class BolsaTrabajoUpdate
    {
        private UpdateCityApp<BolsaTrabajo> UpdateCityApp;

        public BolsaTrabajoUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<BolsaTrabajo>(cityAppContext);
        }
        public Response<object> UpdateBolsaTrabajo(BolsaTrabajo bolsaTrabajo)
        {
            return UpdateCityApp.Save(bolsaTrabajo);
        }
    }
}
