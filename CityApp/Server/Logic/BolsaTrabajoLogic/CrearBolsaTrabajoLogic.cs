using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.BolsaTrabajoLogic
{
    public class CrearBolsaTrabajoLogic
    {
        private BolsaTrabajoQuerys BolsaTrabajoQuerys;

        private BolsaTrabajo BolsaTrabajo;

        public CrearBolsaTrabajoLogic(CityAppContext cityAppContext, BolsaTrabajo bolsaTrabajo)
        {
            BolsaTrabajoQuerys = new BolsaTrabajoQuerys(cityAppContext);

            BolsaTrabajo = bolsaTrabajo;
        }

        public Response<object> Crear()
        {
            return BolsaTrabajoQuerys.InsertBolsaTrabajo(BolsaTrabajo);
        }
    }
}
