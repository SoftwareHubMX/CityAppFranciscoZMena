using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys.Delete
{
    public class ArchivosAnuncioDetete
    {
        private DeleteCityApp<ArchivoAnuncio> DeleteCityApp;

        public ArchivosAnuncioDetete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoAnuncio>(cityAppContext);
        }

        public Response<object> DeleteArchivosAnuncio(IEnumerable<ArchivoAnuncio> archivoAnuncios)
        {
            return DeleteCityApp.SaveMultiple(archivoAnuncios);
        }
    }
}
