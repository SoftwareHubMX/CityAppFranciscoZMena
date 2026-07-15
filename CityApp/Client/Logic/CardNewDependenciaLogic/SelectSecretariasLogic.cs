

using CityApp.Client.Services.ApiRest.DependenciaPeticiones;
using CityApp.Client.Services.ApiRest.SecretariaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewSecretariaLogic
{
    public class SelectSecretariasLogic
    {
        private SecretariaPeticiones SecretariaPeticiones;

        public SelectSecretariasLogic(HttpClient cliente)
        {
            SecretariaPeticiones = new SecretariaPeticiones(cliente);
        }

        public async Task<Response<List<Secretaria>>> SelectAll()
        {
            Response<List<Secretaria>> response = await SecretariaPeticiones.consultarSecretarias();
            return response;
        }
    }
}
