using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys.Update
{
    public class DirectorioUpdate
    {
        private UpdateCityApp<Directorio> UpdateCityApp;

        public DirectorioUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Directorio>(cityAppContext);
        }
        public Response<object> UpdateDirectorio(Directorio directorio)
        {
            return UpdateCityApp.Save(directorio);
        }
    }
}
