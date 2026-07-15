using CityApp.Client.Services.ApiRest.BolsaTrabajoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaBolsaTrabajoLogic
{
    public class InsertBolsaTrabajoLogic
    {
        private BolsaTrabajoPeticiones BolsaTrabajoPeticiones;

        public InsertBolsaTrabajoLogic(HttpClient cliente)
        {
            BolsaTrabajoPeticiones = new BolsaTrabajoPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, BolsaTrabajo bolsaTrabajo)
        {
            Response<object> response = await BolsaTrabajoPeticiones.crearBolsaTrabajo(token, bolsaTrabajo);
            return response;
        }
    }
}
