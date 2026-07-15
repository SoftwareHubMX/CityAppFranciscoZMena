using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ColoniaLogic
{
    public class CrearColoniaLogic
    {
        private ColoniaQuerys ColoniaQuerys;

        private Colonia Colonia;

        public CrearColoniaLogic(CityAppContext cityAppContext, Colonia colonia)
        {
            ColoniaQuerys = new ColoniaQuerys(cityAppContext);

            Colonia = colonia;
        }

        public Response<object> Crear()
        {
            return ColoniaQuerys.InsertColonia(Colonia);
        }
    }
}
