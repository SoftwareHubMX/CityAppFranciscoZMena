using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.BolsaTrabajoLogic
{
    public class ActualizarBolsaTrabajoLogic
    {
        private BolsaTrabajoQuerys BolsaTrabajoQuerys;
        private BolsaTrabajo BolsaTrabajo;
        public ActualizarBolsaTrabajoLogic(CityAppContext cityAppContext, BolsaTrabajo bolsaTrabajo)
        {
            BolsaTrabajoQuerys = new BolsaTrabajoQuerys(cityAppContext);

            BolsaTrabajo = bolsaTrabajo;
        }

        public Response<object> Actualizar()
        {
            return BolsaTrabajoQuerys.UpdateBolsaTrabajo(BolsaTrabajo);
        }
    }
}
