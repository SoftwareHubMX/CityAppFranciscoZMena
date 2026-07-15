using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SecretariaQuerys.Insert
{
    public class SecretariaInsert
    {
        private InsertCityApp<Secretaria> InsertCityApp;

        public SecretariaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Secretaria>(cityAppContext);
        }

        public Response<object> InsertSecretaria(Secretaria secretaria)
        {
            return InsertCityApp.Save(secretaria);
        }
    }
}
