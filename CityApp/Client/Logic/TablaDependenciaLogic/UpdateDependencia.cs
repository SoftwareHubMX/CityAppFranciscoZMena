using CityApp.Client.Services.ApiRest.DependenciaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaDependenciaLogic
{
    public class UpdateDependencia
    {
        private DependenciaPeticiones DependenciaPeticiones;

        public UpdateDependencia(HttpClient cliente)
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
