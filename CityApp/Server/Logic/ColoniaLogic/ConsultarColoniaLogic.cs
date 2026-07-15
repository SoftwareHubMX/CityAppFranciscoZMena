using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ColoniaLogic
{
    public class ConsultarColoniaLogic
    {
        private ColoniaQuerys ColoniaQuerys;


        private int IdColonia;
        private Colonia Colonia;

        public ConsultarColoniaLogic(CityAppContext cityAppContetx, int idColonia)
        {
            ColoniaQuerys = new ColoniaQuerys(cityAppContetx);

            IdColonia = idColonia;
        }

        public Response<Colonia> Consultar()
        {
            return ColoniaQuerys.SelectColoniaIdColonia(IdColonia);
        }
    }
}
