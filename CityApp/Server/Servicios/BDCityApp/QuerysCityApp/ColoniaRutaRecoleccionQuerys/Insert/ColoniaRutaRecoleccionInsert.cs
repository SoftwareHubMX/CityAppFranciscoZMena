using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys.Insert
{
    public class ColoniaRutaRecoleccionInsert
    {
        private InsertCityApp<ColoniaRutaRecoleccion> InsertCityApp;

        public ColoniaRutaRecoleccionInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ColoniaRutaRecoleccion>(cityAppContext);
        }

        public Response<object> InsertColoniaRutaRelcoleccion(ColoniaRutaRecoleccion coloniaRutaRecoleccion)
        {
            return InsertCityApp.Save(coloniaRutaRecoleccion);
        }
    }
}
