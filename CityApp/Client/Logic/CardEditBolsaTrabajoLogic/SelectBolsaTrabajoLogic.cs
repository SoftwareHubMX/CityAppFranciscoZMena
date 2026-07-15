using CityApp.Client.Services.ApiRest.BolsaTrabajoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditBolsaTrabajoLogic
{
    public class SelectBolsaTrabajoLogic
    {
        private BolsaTrabajoPeticiones BolsaTrabajoPeticiones;

        public SelectBolsaTrabajoLogic(HttpClient cliente)
        {
            BolsaTrabajoPeticiones = new BolsaTrabajoPeticiones(cliente);
        }

        public async Task<Response<BolsaTrabajo>> Select(string token, int idBolsaTrabajo)
        {
            Response<BolsaTrabajo> response = await BolsaTrabajoPeticiones.consultarBolsaTrabajo(token, idBolsaTrabajo);
            return response;
        }
    }
}
