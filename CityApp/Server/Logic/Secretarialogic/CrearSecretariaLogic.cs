using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.Secretarialogic
{
    public class CrearSecretariaLogic
    {
        private SecretariaQuerys SecretariaQuerys;

        private Secretaria Secretaria;

        public CrearSecretariaLogic(CityAppContext cityAppContext, Secretaria secretaria)
        {
            SecretariaQuerys = new SecretariaQuerys(cityAppContext);

            Secretaria = secretaria;
        }

        public Response<object> Crear()
        {
            return SecretariaQuerys.InsertSecretaria(Secretaria);
        }
    }
}
