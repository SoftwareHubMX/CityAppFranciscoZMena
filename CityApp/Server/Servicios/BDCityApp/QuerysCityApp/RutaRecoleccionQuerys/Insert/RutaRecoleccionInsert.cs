using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys.Insert
{
    public class RutaRecoleccionInsert
    {
        private InsertCityApp<RutaRecoleccion> InsertCityApp;

        public RutaRecoleccionInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<RutaRecoleccion>(cityAppContext);
        }

        public Response<object> InsertRutaRecoleccion(RutaRecoleccion rutaRecoleccion)
        {
            return InsertCityApp.Save(rutaRecoleccion);
        }
    }
}
