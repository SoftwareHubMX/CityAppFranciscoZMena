using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys.Update
{
    public class SecretariaUpdate
    {
        private UpdateCityApp<Secretaria> UpdateCityApp;

        public SecretariaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Secretaria>(cityAppContext);
        }
        public Response<object> UpdateSecretaria(Secretaria secretaria)
        {
            return UpdateCityApp.Save(secretaria);
        }
    }
}
