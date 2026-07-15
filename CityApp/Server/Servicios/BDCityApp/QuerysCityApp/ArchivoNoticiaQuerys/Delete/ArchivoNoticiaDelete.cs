using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys.Delete
{
    public class ArchivoNoticiaDelete
    {
        private DeleteCityApp<ArchivoNoticia> DeleteCityApp;

        public ArchivoNoticiaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoNoticia>(cityAppContext);
        }

        public Response<object> DeleteArchivoNoticia(ArchivoNoticia archivoNoticia)
        {
            return DeleteCityApp.Save(archivoNoticia);
        }
    }
}
