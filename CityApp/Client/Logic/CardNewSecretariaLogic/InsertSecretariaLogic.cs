using CityApp.Client.Services.ApiRest.SecretariaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewSecretariaLogic
{
    public class InsertSecretariaLogic
    {
        private SecretariaPeticiones SecretariaPeticiones;

        public InsertSecretariaLogic(HttpClient cliente)
        {
            SecretariaPeticiones = new SecretariaPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, Secretaria secretaria)
        {
            Response<object> response = await SecretariaPeticiones.crearSecretaria(token, secretaria);
            return response;
        }
    }
}
