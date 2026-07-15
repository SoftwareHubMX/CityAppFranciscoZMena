using CityApp.Client.Services.ApiRest.SecretariaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditDependenciaLogic
{
    public class SelectSecretariaLogic
    {
        private SecretariaPeticiones SecretariaPeticiones;

        public SelectSecretariaLogic(HttpClient cliente)
        {
            SecretariaPeticiones = new SecretariaPeticiones(cliente);
        }

        public async Task<Response<Secretaria>> Select(string token, int idSecretaria)
        {
            Response<Secretaria> response = await SecretariaPeticiones.consultarSecretaria(token, idSecretaria);
            return response;
        }
    }
}
