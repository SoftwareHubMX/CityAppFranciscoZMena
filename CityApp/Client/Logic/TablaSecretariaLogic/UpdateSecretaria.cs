using CityApp.Client.Services.ApiRest.SecretariaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaSecretariaLogic
{
    public class UpdateSecretaria
    {
        private SecretariaPeticiones SecretariaPeticiones;

        public UpdateSecretaria(HttpClient cliente)
        {
            SecretariaPeticiones = new SecretariaPeticiones(cliente);
        }

        public async Task<Response<object>> Updata(string token,Secretaria secretaria)
        {
            Response<object> response = await SecretariaPeticiones.actualizarSecretaria(token, secretaria);
            return response;
        }
    }
}
