using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys.Delete
{
    public class ArchivosDirectorioDelete
    {
        private DeleteCityApp<ArchivoDirectorio> DeleteCityApp;

        public ArchivosDirectorioDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoDirectorio>(cityAppContext);
        }

        public Response<object> DeleteArchivosDirectorio(IEnumerable<ArchivoDirectorio> archivosDirectorio)
        {
            return DeleteCityApp.SaveMultiple(archivosDirectorio);
        }
    }
}
