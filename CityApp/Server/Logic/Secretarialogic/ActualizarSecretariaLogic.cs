using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.Secretarialogic
{
    public class ActualizarSecretariaLogic
    {
        private SecretariaQuerys SecretariaQuerys;
        private Secretaria Secretaria;
        public ActualizarSecretariaLogic(CityAppContext cityAppContext, Secretaria secretaria)
        {
            SecretariaQuerys = new SecretariaQuerys(cityAppContext);

            Secretaria = secretaria;
        }

        public Response<object> Actualizar()
        {
            return SecretariaQuerys.UpdateSecretaria(Secretaria);
        }
    }
}
