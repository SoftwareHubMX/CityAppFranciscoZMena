using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys.Delete
{
    public class RutaRecoleccionDelete
    {
        private DeleteCityApp<RutaRecoleccion> DeleteCityApp;

        public RutaRecoleccionDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<RutaRecoleccion>(cityAppContext);
        }

        public Response<object> DeleteRutaRecoleccion(RutaRecoleccion rutaRecoleccion)
        {
            return DeleteCityApp.Save(rutaRecoleccion);
        }
    }
}
