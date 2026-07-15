using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ColoniaLogic
{
    public class EliminarColoniaLogic
    {
        private ColoniaQuerys ColoniaQuerys;

        private int IdColonia;

        public EliminarColoniaLogic(CityAppContext cityAppContext, int idColonia)
        {
            ColoniaQuerys = new ColoniaQuerys(cityAppContext);

            IdColonia = idColonia;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Colonia> responseColonia = ColoniaQuerys.SelectColoniaIdColonia(IdColonia);
            response.Status = responseColonia.Status;
            if (response.Status.Exito == 1)
            {
                response = ColoniaQuerys.DeleteColonia(responseColonia.Data);
            }

            return response;
        }
    }
}
