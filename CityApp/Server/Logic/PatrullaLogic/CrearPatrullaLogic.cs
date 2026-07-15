using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PatrullaLogic
{
    public class CrearPatrullaLogic
    {
        private PatrullaQuerys PatrullaQuerys;
        private Patrulla Patrulla = new Patrulla();

        public CrearPatrullaLogic(CityAppContext cityAppContext, Patrulla patrulla)
        {
            PatrullaQuerys = new PatrullaQuerys(cityAppContext);

            Patrulla = patrulla;
        }

        public Response<object> Crear()
        {
            return PatrullaQuerys.InsertPartulla(Patrulla);
        }
    }
}
