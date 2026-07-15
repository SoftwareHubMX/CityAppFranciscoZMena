using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.BolsaTrabajoLogic
{
    public class ConsultarBolsaTrabajoLogic
    {
        private BolsaTrabajoQuerys BolsaTrabajoQuerys;


        private int IdBolsaTrabajo;
        private BolsaTrabajo BolsaTrabajo;

        public ConsultarBolsaTrabajoLogic(CityAppContext cityAppContetx,int idBolsaTrabajo)
        {
            BolsaTrabajoQuerys = new BolsaTrabajoQuerys(cityAppContetx);

            IdBolsaTrabajo = idBolsaTrabajo;
        }

        public Response<BolsaTrabajo> Consultar()
        {
            return BolsaTrabajoQuerys.SelectBolsaTrabajoIdBolsaTrabajo(IdBolsaTrabajo);
        }
    }
}
