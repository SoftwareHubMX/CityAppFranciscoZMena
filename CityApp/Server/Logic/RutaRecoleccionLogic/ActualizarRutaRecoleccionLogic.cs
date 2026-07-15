using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RutaRecoleccionLogic
{
    public class ActualizarRutaRecoleccionLogic
    {
        private RutaRecoleccionQuerys RutaRecoleccionQuerys;
        private RutaRecoleccion RutaRecoleccion;
        public ActualizarRutaRecoleccionLogic(CityAppContext cityAppContext, RutaRecoleccion rutaRecoleccion)
        {
            RutaRecoleccionQuerys = new RutaRecoleccionQuerys(cityAppContext);

            RutaRecoleccion = rutaRecoleccion;
        }

        public Response<object> Actualizar()
        {
            return RutaRecoleccionQuerys.UpdateRutaRecoleccion(RutaRecoleccion);
        }
    }
}
