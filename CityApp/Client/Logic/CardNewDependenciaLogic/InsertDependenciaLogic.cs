using CityApp.Client.Services.ApiRest.DependenciaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewDependenciaLogic
{
    public class InsertDependenciaLogic
    {
        private DependenciaPeticiones DependenciaPeticiones;

        public InsertDependenciaLogic(HttpClient cliente)
        {
            DependenciaPeticiones = new DependenciaPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, Dependencia dependecia)
        {
            Response<object> response = await DependenciaPeticiones.crearDependencia(token, dependecia);
            return response;
        }
    }
}
