using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys.Delete
{
    public class ArchivoAnuncioDelete
    {
        private DeleteCityApp<ArchivoAnuncio> DeleteCityApp;

        public ArchivoAnuncioDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoAnuncio>(cityAppContext);
        }

        public Response<object> DeleteArchivoAnuncio(ArchivoAnuncio archivoAnuncio)
        {
            return DeleteCityApp.Save(archivoAnuncio);
        }
    }
}
