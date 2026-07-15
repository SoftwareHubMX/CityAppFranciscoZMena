using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys.Delete
{
    public class ColoniaRutaRecoleccionDelete
    {
        private DeleteCityApp<ColoniaRutaRecoleccion> DeleteCityApp;

        public ColoniaRutaRecoleccionDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<ColoniaRutaRecoleccion>(cityAppContext);
        }

        public Response<object> DeleteColoniaRutaRecoleccion(ColoniaRutaRecoleccion coloniaRutaRecoleccion)
        {
            return DeleteCityApp.Save(coloniaRutaRecoleccion);
        }
    }
}
