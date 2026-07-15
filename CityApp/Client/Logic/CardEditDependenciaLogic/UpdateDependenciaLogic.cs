using CityApp.Client.Services.ApiRest.DependenciaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditDependenciaLogic
{
    public class UpdateDependenciaLogic
    {
        private DependenciaPeticiones DependenciaPeticiones;

        public UpdateDependenciaLogic(HttpClient cliente)
        {
            DependenciaPeticiones = new DependenciaPeticiones(cliente);
        }

        public async Task<Response<object>> Updata(string token, Dependencia dependencia)
        {
            Response<object> response = await DependenciaPeticiones.actualizarDependencia(token, dependencia);
            return response;
        }
    }
}
