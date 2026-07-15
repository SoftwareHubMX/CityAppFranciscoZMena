using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys.Delete
{
    public class ArchivoDirectorioDelete
    {
        private DeleteCityApp<ArchivoDirectorio> DeleteCityApp;

        public ArchivoDirectorioDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoDirectorio>(cityAppContext);
        }

        public Response<object> DeleteArchivoDirectorio(ArchivoDirectorio archivoDirectorio)
        {
            return DeleteCityApp.Save(archivoDirectorio);
        }
    }
}
