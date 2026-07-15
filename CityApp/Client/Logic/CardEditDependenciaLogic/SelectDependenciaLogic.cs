using CityApp.Client.Services.ApiRest.DependenciaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditDependenciaLogic
{
    public class SelectDependenciaLogic
    {
        private DependenciaPeticiones DependenciaPeticiones;

        public SelectDependenciaLogic(HttpClient cliente)
        {
            DependenciaPeticiones = new DependenciaPeticiones(cliente);
        }

        public async Task<Response<Dependencia>> Select(string token, int idDependencia)
        {
            Response<Dependencia> response = await DependenciaPeticiones.consultarDependencia(token, idDependencia);
            return response;
        }
    }
}
