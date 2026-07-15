using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.Secretarialogic
{
    public class EliminarSecretariaLogic
    {
        private SecretariaQuerys SecretariaQuerys;

        private int IdSecretaria;

        public EliminarSecretariaLogic(CityAppContext cityAppContext, int idSecretaria)
        {
            SecretariaQuerys = new SecretariaQuerys(cityAppContext);

            IdSecretaria = idSecretaria;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Secretaria> responseSecretaria = SecretariaQuerys.SelectSecretariaIdSecretaria(IdSecretaria);
            response.Status = responseSecretaria.Status;
            if (response.Status.Exito == 1)
            {
                response = SecretariaQuerys.DeleteSecretaria(responseSecretaria.Data);
            }

            return response;
        }
    }
}
