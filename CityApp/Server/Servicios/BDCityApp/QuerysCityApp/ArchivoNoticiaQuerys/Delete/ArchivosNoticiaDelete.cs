using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys.Delete
{
    public class ArchivosNoticiaDelete
    {
        private DeleteCityApp<ArchivoNoticia> DeleteCityApp;

        public ArchivosNoticiaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoNoticia>(cityAppContext);
        }

        public Response<object> DeleteArchivosNoticia(IEnumerable<ArchivoNoticia> archivosNoticia)
        {
            return DeleteCityApp.SaveMultiple(archivosNoticia);
        }
    }
}
