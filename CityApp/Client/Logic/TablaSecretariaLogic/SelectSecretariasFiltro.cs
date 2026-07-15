using CityApp.Client.Services.ApiRest.SecretariaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.SecretariaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaSecretariaLogic
{
    public class SelectSecretariasFiltro
    {
        private SecretariaPeticiones SecretariaPeticiones;

        public SelectSecretariasFiltro(HttpClient cliente)
        {
            SecretariaPeticiones = new SecretariaPeticiones(cliente);
        }

        public async Task<Response<List<Secretaria>>> SelectAll(string token, FiltroSecretaria filtroSecretaria)
        {
            Response<List<Secretaria>> response = await SecretariaPeticiones.consultarSecretariasFiltro(token, filtroSecretaria);
            return response;
        }
        

    }
}
