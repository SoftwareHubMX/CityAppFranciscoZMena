using CityApp.Client.Services.ApiRest.PatrullaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaPatrullaLogic
{
    public class DeletePatrulla
    {
        private PatrullaPeticiones PatrullaPeticiones;

        public DeletePatrulla(HttpClient cliente)
        {
            PatrullaPeticiones = new PatrullaPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idPatrulla)
        {
            Response<object> response = await PatrullaPeticiones.eliminarPatrulla(token, idPatrulla);
            return response;
        }
    }
}
