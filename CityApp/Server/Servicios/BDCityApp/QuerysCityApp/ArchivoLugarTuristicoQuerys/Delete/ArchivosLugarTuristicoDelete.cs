using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys.Delete
{
    public class ArchivosLugarTuristicoDelete
    {
        private DeleteCityApp<ArchivoLugarTuristico> DeleteCityApp;

        public ArchivosLugarTuristicoDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoLugarTuristico>(cityAppContext);
        }

        public Response<object> DeleteArchivosLugarTuristico(IEnumerable<ArchivoLugarTuristico> archivosLugarTuristico)
        {
            return DeleteCityApp.SaveMultiple(archivosLugarTuristico);
        }
    }
}
