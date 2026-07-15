using CityApp.Client.Services.ApiRest.DependenciaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DependenciaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaDependenciaLogic
{
    public class SelectDependenciasFiltro
    {
        private DependenciaPeticiones DependenciaPeticiones;

        public SelectDependenciasFiltro(HttpClient cliente)
        {
            DependenciaPeticiones = new DependenciaPeticiones(cliente);
        }

        public async Task<Response<List<Dependencia>>> SelectAll(string token, FiltroDependencia filtroDependencia)
        {
            Response<List<Dependencia>> response = await DependenciaPeticiones.consultarDependenciasFiltro(token, filtroDependencia);
            return response;
        }
    }
}
