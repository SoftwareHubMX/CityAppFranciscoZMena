using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys.Delete
{
    public class DirectorioDelete
    {
        private DeleteCityApp<Directorio> DeleteCityApp;

        public DirectorioDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Directorio>(cityAppContext);
        }

        public Response<object> DeleteDirectorio(Directorio directorio)
        {
            return DeleteCityApp.Save(directorio);
        }
    }
}
