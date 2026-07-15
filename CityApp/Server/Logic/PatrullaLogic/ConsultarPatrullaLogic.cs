using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PatrullaLogic
{
    public class ConsultarPatrullaLogic
    {
        private PatrullaQuerys PatrullaQuerys;
        private int IdPatrulla = 0;

        public ConsultarPatrullaLogic(CityAppContext cityAppContext, int idPatrulla)
        {
            PatrullaQuerys = new PatrullaQuerys(cityAppContext);

            IdPatrulla = idPatrulla;
        }

        public Response<Patrulla> Consultar()
        {
            return PatrullaQuerys.SelectPatrullaIdPatrulla(IdPatrulla);
        }
    }
}
