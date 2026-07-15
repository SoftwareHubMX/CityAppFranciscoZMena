using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ColoniaRutaRecoleccionLogic
{
    public class EliminarColoniaRutaRecoleccionLogic
    {
        private ColoniaRutaRecoleccionQuerys ColoniaRutaRecoleccionQuerys;

        private ColoniaRutaRecoleccion ColoniaRutaRecoleccion;
        

        public EliminarColoniaRutaRecoleccionLogic(CityAppContext cityAppContext, ColoniaRutaRecoleccion coloniaRutaRecoleccion)
        {
            ColoniaRutaRecoleccionQuerys = new ColoniaRutaRecoleccionQuerys(cityAppContext);

            ColoniaRutaRecoleccion = coloniaRutaRecoleccion;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            response = ColoniaRutaRecoleccionQuerys.DeleteColoniaRutaRecoleccion(ColoniaRutaRecoleccion);

            return response;
        }
    }
}
