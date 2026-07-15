using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys.Delete
{
    public class SecretariaDelete
    {
        private DeleteCityApp<Secretaria> DeleteCityApp;

        public SecretariaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Secretaria>(cityAppContext);
        }

        public Response<object> DeleteSecretaria(Secretaria secretaria)
        {
            return DeleteCityApp.Save(secretaria);
        }
    }
}
