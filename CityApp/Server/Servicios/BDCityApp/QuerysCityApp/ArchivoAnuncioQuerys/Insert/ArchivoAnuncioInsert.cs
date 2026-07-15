using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys.Insert
{
    public class ArchivoAnuncioInsert
    {
        private InsertCityApp<ArchivoAnuncio> InsertCityApp;

        public ArchivoAnuncioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ArchivoAnuncio>(cityAppContext);
        }

        public Response<object> InsertArchivoAnuncio(ArchivoAnuncio archivoAnuncio)
        {
            return InsertCityApp.Save(archivoAnuncio);
        }
    }
}
