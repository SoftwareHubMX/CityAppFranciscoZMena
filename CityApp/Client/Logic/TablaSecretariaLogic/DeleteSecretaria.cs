using CityApp.Client.Services.ApiRest.SecretariaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaSecretariaLogic
{
    public class DeleteSecretaria
    {
        private SecretariaPeticiones SecretariaPeticiones;

        public DeleteSecretaria(HttpClient cliente)
        {
            SecretariaPeticiones = new SecretariaPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idSecretaria)
        {
            Response<object> response = await SecretariaPeticiones.eliminarSecretaria(token, idSecretaria);
            return response;
        }
    }
}
