using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ColoniaRutaRecoleccionLogic
{
    public class ConsultarColoniasRutaRecoleccionLogic
    {
        private ColoniaRutaRecoleccionQuerys ColoniaRutaRecoleccionQuerys;
        private int IdRutaRecoleccion;
        private int IdColonia;

        public ConsultarColoniasRutaRecoleccionLogic(CityAppContext cityAppContex, int idRutaRecoleccion, int idColonia)
        {
            ColoniaRutaRecoleccionQuerys = new ColoniaRutaRecoleccionQuerys(cityAppContex);
            IdRutaRecoleccion = idRutaRecoleccion;
            IdColonia = idColonia;  
        }

        public Response<ColoniaRutaRecoleccion> Consultar()
        {
            return ColoniaRutaRecoleccionQuerys.SelectColoniaRutaRecoleccionIdColoniaRutaRecoleccion(IdRutaRecoleccion, IdColonia);
        }
    }
}
