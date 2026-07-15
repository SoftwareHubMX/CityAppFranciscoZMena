using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PatrullaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PatrullaLogic
{
    public class EliminarPatrullaLogic
    {
        private PatrullaQuerys PatrullaQuerys;
        private int IdPatrulla = 0;

        public EliminarPatrullaLogic(CityAppContext cityAppContext, int idPatrulla)
        {
            PatrullaQuerys = new PatrullaQuerys(cityAppContext);

            IdPatrulla = idPatrulla;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Patrulla> responsePatrulla = new Response<Patrulla>();
            responsePatrulla = PatrullaQuerys.SelectPatrullaIdPatrulla(IdPatrulla);
            response.Status = responsePatrulla.Status;
            if(response.Status.Exito == 1)
            {
                response = PatrullaQuerys.DeletePatrulla(responsePatrulla.Data);
            }
            return response;
        }
    }
}
