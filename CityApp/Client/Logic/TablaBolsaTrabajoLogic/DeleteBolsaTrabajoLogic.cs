using CityApp.Client.Services.ApiRest.BolsaTrabajoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaBolsaTrabajoLogic
{
    public class DeleteBolsaTrabajoLogic
    {
        private BolsaTrabajoPeticiones BolsaTrabajoPeticiones;

        public DeleteBolsaTrabajoLogic(HttpClient cliente)
        {
            BolsaTrabajoPeticiones = new BolsaTrabajoPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idBolsaTrabajo)
        {
            Response<object> response = await BolsaTrabajoPeticiones.eliminarBolsaTrabajo(token, idBolsaTrabajo);
            return response;
        }
    }
}
