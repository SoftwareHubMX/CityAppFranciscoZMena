using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ColoniaRutaRecoleccionLogic
{
    public class CrearColoniaRutaRecoleccionLogic
    {
        private ColoniaRutaRecoleccionQuerys ColoniaRutaRecoleccionQuerys;

        private ColoniaRutaRecoleccion ColoniaRutaRecoleccion;

        public CrearColoniaRutaRecoleccionLogic(CityAppContext cityAppContext, ColoniaRutaRecoleccion coloniaRutaRecoleccion)
        {
            ColoniaRutaRecoleccionQuerys = new ColoniaRutaRecoleccionQuerys(cityAppContext);

            ColoniaRutaRecoleccion = coloniaRutaRecoleccion;
            ColoniaRutaRecoleccion.Colonia = null;
        }
        
        public Response<object> Crear()
        {
            return ColoniaRutaRecoleccionQuerys.InsertColoniaRutaRecoleccion(ColoniaRutaRecoleccion);
        }
    }
}
