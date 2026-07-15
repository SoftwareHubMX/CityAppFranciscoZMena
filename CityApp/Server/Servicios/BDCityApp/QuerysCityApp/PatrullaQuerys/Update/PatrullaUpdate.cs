using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys.Update
{
    public class PatrullaUpdate
    {
        private UpdateCityApp<Patrulla> UpdateCityApp;

        public PatrullaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Patrulla>(cityAppContext);
        }

        public Response<object> UpdatePatrulla(Patrulla Patrulla)
        {
            return UpdateCityApp.Save(Patrulla);
        }
    }
}
