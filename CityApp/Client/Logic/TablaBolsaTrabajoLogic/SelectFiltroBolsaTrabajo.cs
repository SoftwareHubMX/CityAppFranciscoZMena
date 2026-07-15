using CityApp.Client.Services.ApiRest.BolsaTrabajoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaBolsaTrabajoLogic
{
    public class SelectFiltroBolsaTrabajo
    {
        private BolsaTrabajoPeticiones BolsaTrabajoPeticiones;

        public SelectFiltroBolsaTrabajo(HttpClient cliente)
        {
            BolsaTrabajoPeticiones = new BolsaTrabajoPeticiones(cliente);
        }

        public async Task<Response<List<BolsaTrabajo>>> SelectAll(string token, FiltroBolsaTrabajo filtroBolsaTrabajo)
        {
            Response<List<BolsaTrabajo>> response = await BolsaTrabajoPeticiones.consultarFiltroBolsaTrabajo(token, filtroBolsaTrabajo);
            return response;
        }
    }
}
