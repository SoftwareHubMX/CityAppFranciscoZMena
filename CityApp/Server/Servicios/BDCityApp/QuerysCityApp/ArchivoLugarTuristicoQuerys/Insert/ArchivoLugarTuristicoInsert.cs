using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys.Insert
{
    public class ArchivoLugarTuristicoInsert
    {
        private InsertCityApp<ArchivoLugarTuristico> InsertCityApp;

        public ArchivoLugarTuristicoInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ArchivoLugarTuristico>(cityAppContext);
        }

        public Response<object> InsertArchivoLugarTuristico(ArchivoLugarTuristico archivoLugarTuristico)
        {
            return InsertCityApp.Save(archivoLugarTuristico);
        }
    }
}
