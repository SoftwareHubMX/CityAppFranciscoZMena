

using CityApp.Client.Services.ApiRest.BolsaTrabajoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEditBolsaTrabajoLogic
{
    public class UpdateBolsaTrabajoLogic
    {
        private BolsaTrabajoPeticiones BolsaTrabajoPeticiones;

        public UpdateBolsaTrabajoLogic(HttpClient cliente)
        {
            BolsaTrabajoPeticiones = new BolsaTrabajoPeticiones(cliente);
        }

        public async Task<Response<object>> Update(string token, BolsaTrabajo bolsaTrabajo)
        {
            Response<object> response = await BolsaTrabajoPeticiones.actualizarBolsaTrabajo(token, bolsaTrabajo);
            return response;
        }
    }
}
