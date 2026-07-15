using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys.Insert
{
    public class ArchivoNoticiaInsert
    {
        private InsertCityApp<ArchivoNoticia> InsertCityApp;

        public ArchivoNoticiaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ArchivoNoticia>(cityAppContext);
        }

        public Response<object> InsertArchivoNoticia(ArchivoNoticia archivoNoticia)
        {
            return InsertCityApp.Save(archivoNoticia);
        }
    }
}
