using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys.Insert
{
    public class ArchivoDirectorioInsert
    {
        private InsertCityApp<ArchivoDirectorio> InsertCityApp;

        public ArchivoDirectorioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ArchivoDirectorio>(cityAppContext);
        }

        public Response<object> InsertArchivoDirectorio(ArchivoDirectorio archivoDirectorio)
        {
            return InsertCityApp.Save(archivoDirectorio);
        }
    }
}
