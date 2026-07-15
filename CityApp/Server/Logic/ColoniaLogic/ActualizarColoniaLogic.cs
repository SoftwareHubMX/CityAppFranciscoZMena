using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ColoniaLogic
{
    public class ActualizarColoniaLogic
    {
        private ColoniaQuerys ColoniaQuerys;
        private Colonia Colonia;
        public ActualizarColoniaLogic(CityAppContext cityAppContext, Colonia colonia)
        {
            ColoniaQuerys = new ColoniaQuerys(cityAppContext);

            Colonia = colonia;
        }

        public Response<object> Actualizar()
        {
            return ColoniaQuerys.UpdateColonia(Colonia);
        }
    }
}
