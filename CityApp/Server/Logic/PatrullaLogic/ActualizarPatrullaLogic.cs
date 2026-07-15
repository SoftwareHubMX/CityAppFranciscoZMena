using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PatrullaLogic
{
    public class ActualizarPatrullaLogic
    {
        private PatrullaQuerys PatrullaQuerys;
        private Patrulla Patrulla = new Patrulla();

        public ActualizarPatrullaLogic(CityAppContext cityAppContext, Patrulla patrulla)
        {
            PatrullaQuerys = new PatrullaQuerys(cityAppContext);

            Patrulla = patrulla;
        }

        public Response<object> Actualizar()
        {
            return PatrullaQuerys.UpdatePartulla(Patrulla);
        }
    }
}
