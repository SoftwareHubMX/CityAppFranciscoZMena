using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.Secretarialogic
{
    public class ConsultarSecretariaLogic
    {
        private SecretariaQuerys SecretariaQuerys;


        private int IdSecretaria;
        private Secretaria Secretaria;

        public ConsultarSecretariaLogic(CityAppContext cityAppContetx, int idSecretaria)
        {
            SecretariaQuerys = new SecretariaQuerys(cityAppContetx);

            IdSecretaria = idSecretaria;
        }

        public Response<Secretaria> Consultar()
        {
            return SecretariaQuerys.SelectSecretariaIdSecretaria(IdSecretaria);
        }
    }
}
