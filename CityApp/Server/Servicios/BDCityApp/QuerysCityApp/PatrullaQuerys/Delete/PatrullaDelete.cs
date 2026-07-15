using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys.Delete
{
    public class PatrullaDelete
    {
        private DeleteCityApp<Patrulla> DeleteCityApp;

        public PatrullaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Patrulla>(cityAppContext);
        }

        public Response<object> DeletePatrulla(Patrulla Patrulla)
        {
            return DeleteCityApp.Save(Patrulla);
        }
    }
}
