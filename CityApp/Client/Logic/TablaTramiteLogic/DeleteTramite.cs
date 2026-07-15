using CityApp.Client.Services.ApiRest.TramitePeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaTramiteLogic
{
    public class DeleteTramite
    {
        private TramitePeticiones TramitePeticiones;

        public DeleteTramite(HttpClient cliente)
        {
            TramitePeticiones = new TramitePeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idTramite)
        {
            Response<object> response = await TramitePeticiones.eliminarTramite(token, idTramite);
            return response;
        }
    }
}
