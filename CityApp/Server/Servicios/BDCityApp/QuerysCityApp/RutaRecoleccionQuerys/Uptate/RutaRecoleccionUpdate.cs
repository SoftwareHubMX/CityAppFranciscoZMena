using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys.Uptate
{
    public class RutaRecoleccionUpdate
    {
        private UpdateCityApp<RutaRecoleccion> UpdateCityApp;

        public RutaRecoleccionUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<RutaRecoleccion>(cityAppContext);
        }
        public Response<object> UpdateRutaRecoleccion(RutaRecoleccion rutaRecoleccion)
        {
            return UpdateCityApp.Save(rutaRecoleccion);
        }
    }
}
