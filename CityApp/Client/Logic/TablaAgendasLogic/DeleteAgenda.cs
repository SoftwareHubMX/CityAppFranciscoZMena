using CityApp.Client.Services.ApiRest.AgendaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaAgendasLogic
{
    public class DeleteAgenda
    {
        private AgendaPeticiones AgendaPeticiones;

        public DeleteAgenda(HttpClient cliente)
        {
            AgendaPeticiones = new AgendaPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idAgenda)
        {
            Response<object> response = await AgendaPeticiones.eliminarAgenda(token, idAgenda);
            return response;
        }
    }
}
