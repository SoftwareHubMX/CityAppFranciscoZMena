using CityApp.Client.Services.ApiRest.SecretariaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewTramiteLogic
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
