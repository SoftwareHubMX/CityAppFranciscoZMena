using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys.Delete
{
    public class ArchivoLugarTuristicoDelete
    {
        private DeleteCityApp<ArchivoLugarTuristico> DeleteCityApp;

        public ArchivoLugarTuristicoDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ArchivoLugarTuristico>(cityAppContext);
        }

        public Response<object> DeleteArchivoLugarTuristico(ArchivoLugarTuristico archivoLugarTuristico)
        {
            return DeleteCityApp.Save(archivoLugarTuristico);
        }
    }
}
