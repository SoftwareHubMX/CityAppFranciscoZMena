using CityApp.Client.Services.ApiRest.GiroPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaBolsaTrabajoLogic
{
    public class SelectGirosLogic
    {
        private GiroPeticiones GiroPeticiones;

        public SelectGirosLogic(HttpClient cliente)
        {
            GiroPeticiones = new GiroPeticiones(cliente);
        }

        public async Task<Response<List<Giro>>> SelectAll()
        {
            Response<List<Giro>> response = await GiroPeticiones.consultarGiros();
            return response;
        }
    }
}
