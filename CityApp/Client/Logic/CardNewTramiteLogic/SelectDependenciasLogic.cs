using CityApp.Client.Services.ApiRest.DependenciaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewTramiteLogic
{
    public class SelectDependenciasLogic
    {
        private DependenciaPeticiones DependenciaPeticiones;

        public SelectDependenciasLogic(HttpClient cliente)
        {
            DependenciaPeticiones = new DependenciaPeticiones(cliente);
        }

        public async Task<Response<List<Dependencia>>> SelectAll(int idSecretaria)
        {
            Response<List<Dependencia>> response = await DependenciaPeticiones.consultarDependencias(idSecretaria);
            return response;
        }
    }
}
